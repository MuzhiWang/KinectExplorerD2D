   M S B A M L   `   `   `  ����  KinectExplorerD2D6    0Northwestern.Kinect.KinectExplorerD2D.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  KinectExplorer-D2D��5   	   $	��640��5   	   $	��800��6    � 	Resources 5         SpecialButton �� 
TargetType �� Triggers P� Property P� Value �� Property �� Value��%�   &	        �� 5   
   " ��6&    5	      P� 5
       �@J�IsMouseOver . . �5      ��  � ��
 �  ��65   5      P� 5       � �� . . �5      ��  � ��
 � � �65   5      5      5      .��5      � $��0,25,0,0q�6    � RowDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      �� 5      	 � ColumnDefinitions	 5   
   �� 5      �� 5       �� 5!      �� 5"      .+�5%   
   (� -   5        $��0��5%      $��0��6   $��2��6F   $��2��6W   $��3,0,95,0q�6k   $	��Top=�6~   .��5'      �� -   5        $��camera1��5'      $��UniformToFill=�6#   5(      (� 5)   
   -   5        $��camera2��5)      $��1��6!   $��2��61   5+      (� 5,   
   $��0��6   $��2��6   $��2��6/   .��5-      �� -   5        $��camera3��5-      $��UniformToFill=�6#   5.      (� 5/   
   $��0��6   $��3��6   $��2��6/   .��50      �� $��20q�6   51      (� 52   
   $��2��6   $��0��6   o� 54   
   $��4��6   $
��Left=�6#   $��22��6>   $��	1,-24,0,0q�6J   $	��Top=�6]   $	��800��6u   .@�55      m� $
��File��6   .@�56      m� $	��New��6   m� 57      $
��Open��6   m� 58      $
��Save��6   59      m� 5:      $��Action��6   .@�5;      m� $
��Play��6   m� 5<      $��Pause��6   m� 5=      $��Store��6   5>      m� 5?      $��About��6   5@      5A      '  !System.Windows.VisualStateManager
   VisualStateGroups
 5C      %  System.Windows.VisualStateGroup  5D   
      States. 5E         System.Windows.VisualState  -   5        DefaultLayout��5G        5H      -   5        MinimalLayout��   
Storyboard. 5I      �� .��5J      T�  �� 
TargetName$ defaultNavigation��64    �� TargetProperty$ 
Visibility�6^   ..�5K      i�  R� KeyTime$ 0��61    R� Value$ 	Collapsed��6=   5L      T� 5M      $ minimalNavigation��64   $ 
Visibility�6^   ..�5N      i� $ 0��61   $ Visible��6=   5O      T� 5P      $ itemGridView��64   $ 
Visibility�6Y   ..�5Q      i� $ 0��61   $ 	Collapsed��6=   5R      T� 5S      $ itemListView��64   $ 
Visibility�6Y   ..�5T      i� $ 0��61   $ Visible��6=   5U      T� 5V      $ itemListView��64   $ ItemTemplate�6Y   ..�5W      i� $ 0��61   $
 10,6��6=   5X      T� 5Y      $ itemListView��64   $ Padding�6Y   ..�5Z      i� $ 0��61   $ 	10,0,0,60��6=   5[      5\      5]        5^      -   5        PortraitLayout��. 5_      �� .��5`      T� $ defaultNavigation��64   $ 
Visibility�6^   ..�5a      i� $ 0��61   $ Visible��6=   5b      T� 5c      $ minimalNavigation��64   $ 
Visibility�6^   ..�5d      i� $ 0��61   $ 	Collapsed��6=   5e      T� 5f      $ itemGridView��64   $ 
Visibility�6Y   ..�5g      i� $ 0��61   $ 	Collapsed��6=   5h      T� 5i      $ itemListView��64   $ 
Visibility�6Y   ..�5j      i� $ 0��61   $ Visible��6=   5k      T� 5l      $ itemListView��64   $ ItemTemplate�6Y   ..�5m      i� $ 0��61   $ Visible��6=   5n      T� 5o      $ itemListView��64   $ Padding�6Y   ..�5p      i� $ 0��61   $ 	60,0,0,10��6=   5q      5r      5s      5t      5v      