   M S B A M L   `   `   `  ����E  ATA.Desktop, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:TA.Desktop.Views.WindowsTA.Desktop.Views.Windows  5   	   1    +TA.Desktop.Views.Windows.WorkerEditorWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:TA.Desktop.Views.Windows     5   	     � Title$3  -Добавление пользователя��5   	   $	��250��6)   $	��400��66    � WindowStartupLocation$ CenterScreen=�6B   .��5	      �  � RowDefinitions 5
   
   �� 5      �� 5      �� 5      �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� $��1��6   $��0��6!   $��22(�61   $��
Логин��6?   $��10q�6L   $��Center=�6X    �� TextAlignment$ Center=�6s   �� 5   
   -   5         ��Name$ edLogin��5      $��1��6#   $��5q�60   $��1��6;   $��24��6K   �� 5   
   $��2��6   $��0��6!   $��22(�62   $��Пароль��6@   $��10q�6N   $��Center=�6Z   $ Center=�6u   G� 5   
   -   5         G�Name$ 
edPassword��5   >   $��2��6   $��1��6#   $��5q�63   $��24��6R   �� 5   
   $��0��6   $��0��6!   $��22(�62   $��Роль��6@   $��10q�6L   $��Center=�6X   $ Center=�6s   �� 5   
   -   5         ��Name$ roleBox��5      $��0��6$   $��1��61   $��25��6A   $��5q�6M   �� 5   
    �� Orientation$ 
Horizontal=�6   $��Right=�6.   $��Center=�6J   $��3��6e   $��7��6y   .+�5      �� -   5        	 ��Name$	 	btnCancel��5   J   $��5��6-   $��0��6:   $��Отмена��6]   �� 5       -   5        $	 btnAdd��5    G   $��5��6*   $��1��67   $��Сохранить��6W   5!      5"      5#      