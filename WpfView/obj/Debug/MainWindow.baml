   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   B >WpfView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfViewWpfView 5   	   Q MWarriorsDomain.Classes, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:WarriorsDomain.Classes;assembly=WarriorsDomain.ClassesWarriorsDomain.Classes 5   	   kJclr-namespace:WarriorsDomain.Classes.Enums;assembly=WarriorsDomain.ClassesWarriorsDomain.Classes.Enums 5	   	      WpfView.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   'localclr-namespace:WpfView     5   	   XClassesDclr-namespace:WarriorsDomain.Classes;assembly=WarriorsDomain.Classes     5   	   \EnumsJclr-namespace:WarriorsDomain.Classes.Enums;assembly=WarriorsDomain.Classes     5	   	   -   5          � Title$  
MainWindow��5   	   $��591.5��6   $��914.8��6+    � 	Resources 5         warriorViewSource # warriorEquipmentOwnedViewSource �� Source �� Source  dataFromEnum S� 
MethodName S� 
ObjectType   System.Enum S� MethodParameters M� TypeName �� 
TargetType  	baseStyle	 �� Property
 �� Value �� BasedOn&   System.Windows.Controls.DataGrid(  "System.Windows.Controls.DatePicker  warriorViewSource1 $  warriorEquipmentOwnedViewSource1��%�  &	        &	      7   &	 G     &	 �     '��     7  '�� %    7  '�� G    7  '�� i    7  '  �    7  '  �    7  '�� �    7  &	 �    &	     7  S� 5   
   6   �� 5   
    6G   �� *EquipmentOwned+8   S� 5   
   $ 	GetValues��5      "  6%    5      M� 5      $ Enums:EquipmentType��6   5      �� 5   
   " ��6   .�5      �� 	 � ��$
 20(�6)   5      �� 5   
   " ��6   8   6T   �� 5   
   " ��6   8   6S   �� 5   
   " ��6   8   6U   �� 5    
   " ��6   8   6V   �� 5!   
   "  6   8   6V   �� 5"   
   "  6   8   6X   �� 5#   
   " ��6   8   6V   �� 5$   
   6   �� 5%   
    6H   �� *EquipmentOwned+8   5(      .��5*      �  � DataContext# [ 6   $	��553��6J   $	��Top=�6W   .+�5+   
   � -   5         �Name$ grid1��5+      # [  6   $
��Left=�6O   $��
52,170,0,0q�6j   $	��Top=�6~    � ColumnDefinitions 5,      �� 5-      $
��Auto �6#   $	��132��60   �� 5.      $
��Auto �6#   $	��129��60    � RowDefinitions 50      �� 51      $
��Auto �6    �� 52      $
��Auto �6    �� 53      $
��Auto �6    �� 54      $
��Auto �6    �� 55      $
��Auto �6    �� 56      $
��Auto �6    �� 57      $
��Auto �6    �� 58      $
��Auto �6    �� 59      $
��Auto �6    .+�5;      �� $��Name:��6   $��0��6$   $
��Left=�64   $��3,3,0,3q�6O   $��0��6`   $��Center=�6m   $��37��6�   $��67��6�   �� 5<      -   5         ��Name$ nameTextBox��5<      $
��Left=�6+   $��30��6F   $��75,10,-97,3q�6R   $��0��6g   $��Center=�6�   $	��304��6�   $��2��6�   ��6t   �� *Name+ �� Mode$ TwoWay=� �� NotifyOnValidationError .  �� ValidatesOnExceptions . 6  �� 5>      $��Clan:��6   $��0��6$   $
��Left=�64   $��3,3,0,0q�6O   $��1��6`   $	��Top=�6m   $��37��6�   $��53��6�   �� 5?      -   5         ��Name$ bloodComboBox��5?       �� DisplayMemberPath$ 	BloodName��5@      $
��Left=�5A      $��28��62    �� SelectedValuePath$ Id��5C      $��61,10,-85,18q�5G      $��1��6-   $��Center=�5H      $	��302��62   $��2��5I      ��5B      ��  �� SelectedValue 5D      ��  �� ElementName$ warriorListBox�� �� Path$ SelectedItem.BloodId�$ OneWayToSource=�5I      �� 5J      $��Date of Birth:��6   $��0��6-   $
��Left=�6=   $��3,3,0,3q�6X   $��4��6i   $��Center=�6v   $��37��6�   $	��129��6�     5K      -   5          Name$ dateOfBirthDatePicker��5K      $��1��68   $
��Left=�6H   $��
3,9,-61,10q�6c   $��4��6w   $��Center=�6�   $��24��6  $	��190��6  $��14.667(�6#     SelectedDate 6�   �� *DateOfBirth+$ TwoWay=� .  . 65  �� 5L      $��Served In Kingdom:��6   $��0��61   $
��Left=�6A   $��3,10,0,3q�6\   $��8��6n   $��Center=�6{   $��56��6�   $	��196��6�   $��2��6�   �� 5M      -   5         ��Name$ servedInKingdomCheckBox��5M      $�� ��68   $��1��6C   $��Right=�6S   $��
0,23,44,20q�6�   $��8��6�   $��Center=�6�   $��26��6  $��20��6$   d� 	IsChecked 6o   �� *ServedInKingdom+$ TwoWay=� .  . 6Z  5N      �� 5O   
   -   5         ��Name$ warriorListBox��5O      $
��Left=�6*   $��71��6E   $��	70,49,0,0q�6Q   $	��Top=�6d   $	��362��6|   $ Id��6�   $
 Name��6�   �� 5P   
   -   5         ��Name$ btnNewWarrior��5P      $��70,386,679,0q�6(   $��New Warrior��6>   $��31��6p   $	��Top=�6|     5Q   
   -	   5           Name$  equipmentOwnedDataGrid��5Q      !   AutoGenerateColumns! .  "   EnableRowVirtualization" . $��482,152,37,0q�5R   +   #   RowDetailsVisibilityMode$# VisibleWhenSelected=�5S      $	��321��5T   J   $	��Top=�6W   ��5R      �� $   Columns$ 5X      0  *System.Windows.Controls.DataGridTextColumn  5Y      -
   5        idColumn��,  &System.Windows.Controls.DataGridColumn%   Header$% Id��5Y   N   &   Width5  /System.Windows.Controls.DataGridLengthConverter$& SizeToHeader 6Z   '   
Visibility$' Hidden=�6o   1  +System.Windows.Controls.DataGridBoundColumn(   Binding( 67   �� *Id+6o     5Z      -   5        
nameColumn��$
% Name��5Z   R   $& 6* 6`   ( 69   �� *Name+6`   4  .System.Windows.Controls.DataGridComboBoxColumn  5[      -   5        equipTypeColumn��$
% Type��5^   )   $& 4* 67   )   SelectedItemBinding) 5\   )   �� *Type+*   ItemsSource* 5]   )   �� # [ 5^   7   5l      �� 5m   
   -   5        $ BtnSave��5m      $
��Save��6"   $
��Left=�61   $��27��6L   $��766,496,0,0q�6X   $	��Top=�6m   $	��104��6�   6�   5o      5p      