   M S B A M L   `   `   `  ����E  ATA.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TA.Desktop.Views.WindowsTA.Desktop.Views.Windows  5   	   ,    &TA.Desktop.Views.Windows.ClientsWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:TA.Desktop.Views.Windows     5   	     � Title$  Клиенты��5   	   $	��450��6   $	��400��6&    � WindowStartupLocation$ CenterScreen=�62    � 	Resources 5	       �� 
TargetType �� Property �� Value��%�   '��       �� 5
   
   " ��6   .�5      ��  � ��$ Center=�6;   �� 5       � ��$ Center=�69   �� 5       � ��$ 5q�6'   �� 5       � ��
 �����6+   5      5      .��5      �  � RowDefinitions 5   
   �� 5      $��25 �6   �� 5      .+�5   
   o� .@�5      m� -   5         m�Name$ btnAddClient��5      $��25��6-    m� Icon 5      �� 5      $��/Images/Add.png��6   5      m� 5      -   5        $ btnEditClient��5      $��25��6.    5      �� 5      $��/Images/Edit.png��6   5!      m� 5"      -   5        $ btnDeleteClient��5"      $��25��60    5#      �� 5$      $��/Images/Delete.png��6   5&      5'      �� 5)   
   -   5        	 ��Name$	 
clientsBox��5)      $��1��6H   
�������
 �� SelectionMode$
 Single=�6l   ��6&   �� *	Customers+��5*      �� 5+      .R�5,      A�  A� Columns$ 1��6"   $	��Top=�6.   5-      ��5/      �� 50      .R�51      � $��16(�6    �� TextAlignment$ Center=�63   .+�52      �� $
��Bold"�6>   $��Center=�6P   ��6$   �� *
Initials+6P   53      54      56      57      58      