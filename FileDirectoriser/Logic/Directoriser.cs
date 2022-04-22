using Fortah.FileDirectoriser.Generic;
using Fortah.FileDirectoriser.Toolkits;
using System;
using System.Collections.ObjectModel;
using System.IO;

namespace Fortah.FileDirectoriser.Logic {
    internal class Directoriser {
        private string SourceDirectoryPath { get; }
        private string DestinationDirectoryPath { get; }
        private int NoOfCharacters { get; }
        private CaseType Case { get; }

        private ObservableCollection<Message> Messages { get; }

        private Worker? Worker { get; set; }
        private int CountOf { get; set; }
        private int Progress { get; set; }

        public Directoriser(string pSourceDirectoryPath, string pDestinationDirectoryPath, int pNoOfCharacters, CaseType pCase, ObservableCollection<Message> pMessages) {
            this.SourceDirectoryPath = pSourceDirectoryPath;
            this.DestinationDirectoryPath = pDestinationDirectoryPath;
            this.NoOfCharacters = pNoOfCharacters;
            this.Case = pCase;

            this.Messages = pMessages;
            
            this.Worker = null;
            this.CountOf = 0;
            this.Progress = 0;
        }

        public void Run(Worker? pWorker = null) {
            this.Worker = pWorker;
            if (this.Validate())
                if (this.Count())
                    this.Process();
        }

        private bool Validate() {
            bool Result = true;
            if (!string.IsNullOrEmpty(this.SourceDirectoryPath)) {
                if (!Directory.Exists(this.SourceDirectoryPath))
                    Result = this.ReportError(string.Format(Resources.Texts.CannotBeFound, Resources.Texts.SourceDirectoryPath));
            } else
                Result = this.ReportError(string.Format(Resources.Texts.CannotBeEmpty, Resources.Texts.SourceDirectoryPath));
            if (string.IsNullOrEmpty(this.DestinationDirectoryPath))
                Result = this.ReportError(string.Format(Resources.Texts.CannotBeEmpty, Resources.Texts.DestinationDirectoryPath));
            return Result;
        }

        private bool Count() {
            bool Result = true;
            this.CountOf = Directory.GetDirectories(this.SourceDirectoryPath).Length + Directory.GetFiles(this.SourceDirectoryPath).Length;
            if (this.CountOf == 0)
                Result = this.ReportError(string.Format(Resources.Texts.NoContent, Resources.Texts.DestinationDirectoryPath));
            return Result;
        }

        private void Process() {
            this.ClearProgress();

            FileSystemToolkit.MakeSureDirectoryTreeExists(this.DestinationDirectoryPath);

            bool InProgress = true;

            if (InProgress) {
                string[] SubDirectoryPaths = Directory.GetDirectories(this.SourceDirectoryPath);
                InProgress = this.Process(SubDirectoryPaths, (pDestination) => { return Directory.Exists(pDestination); }, 
                    (pSource, pDestination) => { Directory.Move(pSource, pDestination); }, (pName) => { return $"[{pName}]"; });
            }

            if (InProgress) {
                string[] FilePaths = Directory.GetFiles(this.SourceDirectoryPath);
                InProgress = this.Process(FilePaths, (pDestination) => { return File.Exists(pDestination); }, 
                    (pSource, pDestination) => { File.Move(pSource, pDestination); });
            }
        }

        private void ClearProgress() {
            this.Progress = 0;
            this.ReportProgress();
        }

        private void UpdateProgress(int pProgressChange, string? pMessage = null, MessageType? pMessageType = MessageType.Information) {
            this.Progress += pProgressChange;
            this.ReportProgress(pMessage, pMessageType);
        }

        private bool ReportError(string pMessage) {
            this.ReportProgress(pMessage, MessageType.Error);
            return false;
        }

        private void ReportProgress(string? pMessage = null, MessageType? pMessageType = MessageType.Information) {
            MessageType MessageType = pMessageType != null ? pMessageType.Value : MessageType.Information;
            Message? Message = !string.IsNullOrEmpty(pMessage) ? new Message(MessageType, pMessage) : null;
            int Progress = this.CountOf != 0 ? (int)Math.Round(((decimal)this.Progress) / this.CountOf * 100, 0) : 0;
            this.Worker?.ReportProgress(Progress, Message);
        }

        private bool Process(string[] pItemPaths, Func<string, bool> pExists, Action<string, string> pMove, Func<string, string>? pCreateItemMessage = null) {
            bool InProgress = true;

            foreach (string ItemPath in pItemPaths) {
                MessageType ProgressMessageType = MessageType.Information;
                string ProgressComment = string.Empty;

                string ItemName = Path.GetFileName(ItemPath);
                
                DirectoryTree DestinationDirectoryTree = DirectoryTree.Create(ItemName, this.NoOfCharacters, this.Case);
                string DestinationDirectoryPath = Path.Combine(this.DestinationDirectoryPath, DestinationDirectoryTree.Result);
                FileSystemToolkit.MakeSureDirectoryTreeExists(DestinationDirectoryPath);

                string SourcePath = Path.Combine(this.SourceDirectoryPath, ItemName);
                string DestinationPath = Path.Combine(DestinationDirectoryPath, ItemName);

                if (!pExists(DestinationPath)) {
                    try {
                        pMove(SourcePath, DestinationPath);
                        if (DestinationDirectoryTree.ReservedNameDetected) {
                            ProgressMessageType = MessageType.Warning;
                            ProgressComment = Resources.Texts.ReservedDirectoryNameDetected;
                        }
                    } catch (Exception Error) {
                        ProgressMessageType = MessageType.Error;
                        ProgressComment = Error.Message;
                    }
                } else {
                    ProgressMessageType = MessageType.Error;
                    ProgressComment = Resources.Texts.ExistsAlready;
                }

                string ItemMessage = pCreateItemMessage != null ? pCreateItemMessage(ItemName) : ItemName;
                string ProgressMessage = $"{ItemMessage} -> {DestinationDirectoryTree.Result}.";
                if (!string.IsNullOrEmpty(ProgressComment))
                    ProgressMessage = $"{ProgressMessage} {ProgressComment}.";

                this.UpdateProgress(1, ProgressMessage, ProgressMessageType);

                if (this.Worker != null)
                    if (this.Worker.CancellationPending) {
                        InProgress = false;
                        break;
                    }
            }

            return InProgress;
        }
    }
}
