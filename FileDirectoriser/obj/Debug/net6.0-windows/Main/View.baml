   M S B A M L   `   `   `  ����K  GFileDirectoriser, Version=2.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:Fortah.FileDirectoriser.LogicFortah.FileDirectoriser.Logic  5   	   K*clr-namespace:Fortah.FileDirectoriser.MainFortah.FileDirectoriser.Main  5   	   G(clr-namespace:Fortah.FileDirectoriser.UIFortah.FileDirectoriser.UI  5   	   I)clr-namespace:Fortah.FileDirectoriser.WPFFortah.FileDirectoriser.WPF  5	   	   '    !Fortah.FileDirectoriser.Main.View   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =logic+clr-namespace:Fortah.FileDirectoriser.Logic     5   	   ;main*clr-namespace:Fortah.FileDirectoriser.Main     5   	   7ui(clr-namespace:Fortah.FileDirectoriser.UI     5   	   9wpf)clr-namespace:Fortah.FileDirectoriser.WPF     5	   	     � Title$  File Directoriser��5   	   $	��512��6#   $	��768��60    � Icon$, &/Resources/Images/Application32x32.png��6<    � 	Resources 5         DirectoryPathBox �� 
TargetType �� Orientation �� RelativeSource �� Path �� Mode  
IntegerBox �� 
TargetType  ActionButton	 �� Property
 �� Value:   4Fortah.FileDirectoriser.UI.MessageTypeImageConverter  MessageTypeImageConverter��%  &	        &	 �    &	 M    &	 �    �� 5   
   " ��63   .R�5      �� $ 
Horizontal=�6   $
��Left=�62   $��Center=�6M   $��0 4 4 0q�6h   .+�5      �� $
��Left=�6   $��Center=�65   $	��484��6P   $��24��6\   ��5      ��  �� *TemplatedParent+$
 Text�$ TwoWay=��� 5      $��24��6   $��24��6$   $��4 0 0 0q�60   ��5      ��  �� *TemplatedParent+$, &(ui:DirectoryPathBoxProperties.Select)�.��6�   …6�   5      5      �� 5   
   " ��6-   .R�5      �� $ 
Horizontal=�6   $
��Left=�62   $��Center=�6M   $��0 4 4 0q�6h   .+�5      �� -   5        $��Right=�5      $��Center=�66   $��72��6Q   $��24��6\   ��5      ��  �� *TemplatedParent+$
 Text�$ TwoWay=�6n   �� 5      $��24��6   $��24��6$   $��4 0 0 0q�60   ��5      ��  �� *TemplatedParent+$( "(ui:IntegerBoxProperties.Decrease)�.��6�   ▼6�   �� 5      $��24��6   $��24��6$   $��4 0 0 0q�60   ��5      ��  �� *TemplatedParent+$( "(ui:IntegerBoxProperties.Increase)�.��6�   ▲6�   5      5      �� 5    
   " ��6   .�5!      �� 	 � ��$	
 128��6&   �� 5"      	 � ��$
 24��6'   �� 5#      	 � ��$
 4 4 4 4q�6'   5$        5%   
   6'   5&      .��5'      �  � RowDefinitions 5(   
   �� 5)      $
��Auto �6   �� 5*      $��* �6   �� 5+      $
��Auto �6   .+�5-   
   � $��0��6    5.      �� 5/      $
��Auto �6    �� 50      $
��Auto �6    �� 51      $
��Auto �6    �� 52      $
��Auto �6     � ColumnDefinitions 54      �� 55      $
��Auto �6#   �� 56      $��* �6#   .+�58      �� $��0��6   $��0��6!   .��61   Source Directory Path6H   �� 59      -   5        $ ��SourceDirectoryPathTextBox��59      $��0��68   $��1��6E   #��[  6U   ��5:      �� *SourceDirectoryPath+;   5Fortah.FileDirectoriser.UI.DirectoryPathBoxProperties   Select 66   �� *SelectSourceDirectoryCommand+�� 5;      $��1��6   $��0��6!   .��61   Destination Directory Path6M   �� 5<      -   5        $%��DestinationDirectoryPathTextBox��5<      $��1��6=   $��1��6J   #��[  6Z   ��5=      �� *DestinationDirectoryPath+ 6;   �� *#!SelectDestinationDirectoryCommand+�� 5>      $��2��6   $��0��6!   .��61   No. of Characters6D   �� 5?      $��2��6   $��1��6#   #��[ 63   ��6Z   �� *NoOfCharacters+5   /Fortah.FileDirectoriser.UI.IntegerBoxProperties   Decrease 5@      �� *DecreaseNoOfCharactersCommand+   Increase 5A      �� *IncreaseNoOfCharactersCommand+�� 5B      $��3��6   $��0��6!   .��61   Case67   �� 5C      $��3��6   $��1��6$   $	��128��64   $
��Left=�6@   $��0 4 4 0q�6[    �� SelectedItem 5D      �� *Case+��6/   5   /Fortah.FileDirectoriser.WPF.EnumMarkupExtension  *logic:CaseType+5E      � 5F   
   $��1��6    5G      �� 5H      $
��Auto �6    �� 5I      $��* �6    .+�5K      � $��0��6   $��24��6'   $��4 4 4 0q�63    � Minimum$ 0Q�6_    � Maximum$	 100Q�6k    � Value 6D   �� *
Progress+6{   �� 5L      $��1��6   $��4 4 4 0q�6$   ��65   �� *
Messages+��5M      �� 5N      .R�5O      �� $ 
Horizontal=�6%   .+�5P      �� $��16��6$   $��16��6/   $��0 0 4 0q�6�   ��6;   �� *Type+ �� 	Converter# [ 6�   �� 5Q      ��6(   �� *Text+5R      5S      5U      5V      � 5W   
   $��2��6    5X      �� 5Y      $
��Auto �6#   �� 5Z      $��* �6#   .+�5\      �� $��0��6   $��4 0 0 0q�6F   
������ $��0q�6p   ��6%   �� *AboutCommand+.��5]      �� $��24��6   $��24��6#   $,��&/Resources/Images/Application24x24.png��6/   5^      �� 5_      $��1��6   $ 
Horizontal=�6)   $��Right=�6B   $��Center=�6_   .+�5`      �� -   5        $��	RunButton��5`      #��[ 6*   ��6P   �� *
RunCommand+.��6o   Run6t   �� 5a      -   5        $��
StopButton��5a      #��[ 6+   ��6Q   �� *StopCommand+.��6q   Stop6w   �� 5b      -   5        $��ResetButton��5b      #��[ 6,   ��6R   �� *ResetCommand+.��6s   Reset6z   5c      5d      5e      5f      