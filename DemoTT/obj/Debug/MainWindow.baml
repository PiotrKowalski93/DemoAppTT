   M S B A M L   `   `   `  ����
  DemoTT    DemoTT.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0ignorehttp://www.galasoft.ch/ignore     5   	   $	��500��5   	   $	��700��5	   	     � Title$
  Demo��5
   	    � DataContext 5   	   �� *Main+   Locator �� Source# [   � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ Skins/MainSkin.xaml?�6%   %    5      .��5      � ���	#FFBBBBBB � ColumnDefinitions 5   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   $	��300��6*   �� 5      $
��Auto �6   .+�5!   
   �� $��0��6   $��0��6   $��Center=�6-   $��Clients:��6J   $��16(�6]   �� 5"   
   $��0��6   $��1��6   $��Center=�6-   $��Taxi Drivers:��6J   $��16(�6b   &   System.Windows.Controls.DataGrid  5$   
   -   5          Name$ Clients��5$      $��1��6D   $��0��6Q   	   AutoGenerateColumns	 .  $	��5,5q�6}   ��6$   �� *	Clients+
   Columns
 5%      0  *System.Windows.Controls.DataGridTextColumn  5&      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *Id+  5'      $ Status��6%    65   �� *Status+5)        5+   
   -   5        $ Drivers��5+      $��1��6D   $��1��6Q   	 .  $	��5,5q�6}   ��6$   �� *	Drivers+
 5,        5-      $ Id��6%    61   �� *Id+  5.      $ Status��6%    65   �� *Status+  5/      $ ClientId��6%    67   �� *
ClientId+51      �� 53   
   -   5         ��Name$ Start��53      $��2��6A   $��Start��6N   $��50��6^   $	��5,5q�6i   ��6    �� *StartCommand+6i   55      56      