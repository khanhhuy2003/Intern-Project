   M S B A M L   `   `   `  ����>  :UI2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:UI2.User_ControlsUI2.User_Controls  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	       UI2.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .ucclr-namespace:UI2.User_Controls     5   	   X TFontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10fFfa=http://schemas.awesome.incremented/wpf/xaml/fontawesome.sharp  5   	   >lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	    oxyhttp://oxyplot.org/wpf  5	   	   $	��680��5
      $
��1250��6'     � WindowStartupLocation$  CenterScreen=�64    � WindowStyle$
 None=�5   	    � AllowsTransparency$
 True��6   
������ .��5      �  � ColumnDefinitions 5   
   �� 5      $	��250 �6   �� 5      $��* �6   .+�5   
   �� ��5      �� 5       �� 
StartPoint$ 0.5,0&�6&    �� EndPoint$ 0.5,1&�69   .��5      �  � Color$ #223266��6#    � Offset$ 0Q�63   � 5      $ #27396a��6#   $ 1Q�63   5      5      �� 5   
   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��Center=�62   $��0 35 0 0q�6O   .+�5       �� $��Kimberly - Clark��6   ���#5b60c4$��22(�6I   $
��Bold"�6W   $��Center=�5!      $��Center=�6*   $��3,4,0,0q�6G   5#      �� 5%      $ 
Horizontal=�6   $��Center=�62   $��0 4 0 0q�6O   .+�5'      �� $��Viet Nam��6   ���#5b60c4$��20(�6A   $
��Bold"�6O   $��Center=�5(      $��Center=�6   5*      �� 5,      $	��0.8��6   $��20 30q�6%   ���#46558a64   �� 5.         
menuButton#��[  6   .��5/      �� $ 
Horizontal=�6   .+�50      !  FontAwesome.Sharp.IconImage  �  �FontAwesome.Sharp.IconImageBase`1[[FontAwesome.Sharp.IconChar, FontAwesome.Sharp, Version=6.3.0.0, Culture=neutral, PublicKeyToken=d16d1e4e568ec10f]]	   Icon$	 TabletScreenButton=�6#     menuButtonIcon#��[ 6=   �� 51      $��Main Screen��6      menuButtonText#��[ 63   52      54      �� 56      #��[  6   .��57      �� $ 
Horizontal=�6   .+�58        $	 History=�6#   #��[ 62   �� 59      $��History��6    #��[ 6/   5:      5<      �� 5?      #��[  6   .��5@      �� $ 
Horizontal=�6   .+�5A        $	 Search=�6#   #��[ 61   �� 5B      $��Search��6    #��[ 6.   5C      5E      �� 5G      #��[  6   .��5H      �� $ 
Horizontal=�6   .+�5I        $
	 Gear=�6#   #��[ 6/   �� 5J      $��Settings��6    #��[ 60   5K      5M      5N      �� 5Q   
   $��1��6   
 �� CornerRadius$
 	0 10 10 0��6!   ��5R      �� 5S      $	 1,0&�6&   $	 0,1&�67   .��5T      � $ #41518f��6#   $ 0Q�63   � 5U      $ #2c386c��6#   $ 1Q�63   5V      ._�5Z      �  � RowDefinitions 5[      �� 5\      $
��auto �6$   �� 5]      $	��200 �6$   �� 5^      $��* �6$   .+�5b      �� $ 
Horizontal=�6   $��Bottom=�66   $��Right=�6Q   $��	0 0 30 20q�6m   .+�5c      �� -   5         ��Name$ MachineComboBox��5c        ComboBoxStyle#��[ 6l   .@�5d      �� -   5         ��Name$ PlaceholderItem��5d   '   ${�False��6@   
�������6R   �� 5e      $
��BD04��6'     ComboBoxItemStyle#��[ 66   ���#5b60c4���#ffffff6w   �� 5f      $
��BD05��6'   #��[ 66   ���#5b60c4���#ffffff6w   �� 5g      $
��BD06��6'   #��[ 66   ���#5b60c4���#ffffff6w   �� 5h      $
��BD07��6'   #��[ 66   ���#5b60c4���#ffffff6w   �� 5i      $
��BD08��6'   #��[ 66   ���#5b60c4���#ffffff6w   �� 5j      $
��BD09��6'   #��[ 66   ���#5b60c4���#ffffff6w   �� 5k      $
��BD10��6'   #��[ 66   ���#5b60c4���#ffffff6w   5l      �� 5m      -   5        $��Today��5m        topMenuButton#��[ 6-   ���#5b60c4���#ffffff6~   �� 5n      -   5        $�� Last 7 days��5n      #��[ 64   ���#5b60c4���#ffffff6�   �� 5o      -   5        $��Last 14 days��5o      #��[ 64   ���#5b60c4���#ffffff6�   �� 5p      -   5        $��
Last Month��5p      #��[ 62   ���#5b60c4���#ffffff6�   5q      �� 5s      $��Welcome, Huy��6   $��26(�60   ���#ccc7ff$
��Left=�6S   $��
50 35 0 20q�6n   � 5v      $��1��6   $��50 20 15 40q�6$    5w      �� 5x      $��* �6+   �� 5y      $��* �6+   �� 5z      $��* �6+   .+�5|          UI2.User_Controls.InfoCard  $��0��6"      StackerTitle$ Stacker��62      Background1$ #827bff��6o      Background2$ #d9b5ff��6�      EllipseBackground1$ #b298fd��5}         EllipseBackground2$ #e4bbff��64      StackerSpeed 5|   I   �� *StackerSpeed+5}   4     5~      $��1��6"      OEETitle$	 OEE��62   $ #fd8a87��6U   $ #f3ab92��6k   $ #fbd5a8��5      $ #fdb89b��64   
   OEE 5~   A   �� *OEE+5   4     5�      $��2��6"      
WasteTitle$ Waste��62   $ #fc84cb��6]   $ #fc8fae��6s   $ #fc8fae��5�      $ #ffabe6��64      Waste 5�   E   �� *Waste+5�   4   5�      � 5�      $��2��6    5�      �� 5�      $��* �6+   �� 5�      $	��310 �6+   .+�5�      �� $
 20��6    �� Padding$ 35 25q�6/   ���#243771$��
50 0 10 40q�6T   ._�5�      �  5�      �� 5�   "   $
��Auto �60   �� 5�   "   $��* �60   .+�5�      �� $��0��6(   $��Actual Speed��65   $��20(�6I   $
��Bold"�6W   ���#ffffff$��Center=�6~   $	��Top=�6�   $��0,10,0,0q�6�   #  LiveCharts.Wpf.CartesianChart  5�      -   5        $��chart��5�   >   $��1��61   &   LiveCharts.Wpf.Charts.Base.Chart   LegendLocation$
 None=�6s      Series 6K   �� *LineSeriesCollection+   AxisX 5�   &     LiveCharts.Wpf.Axis     Title$
 Time��6/      Labels 6<   �� *Labels+   	Separator 5�   *     LiveCharts.Wpf.Separator  5�   .      Step$ 1Q�6<   5�   '       AxisY  5�   &     $ Value��6/   !   MinValue$! 0Q�6=   "   MaxValue$
" 2000Q�6J    5�   *     5�   .   $	 200Q�6<   5�   '   5�      5�      5�      �� 5�      $��1��6   $
 20��6-   $
 0 25q�6?   ���#243771$��
15 0 47 40q�6c   ._�5�      �  5�      �� 5�   "   $
��auto �60   �� 5�   "   $��* �60   .+�5�      �� $ 
Horizontal=�6)   $��	20 0 0 15q�6B   .+�5�   "     $	 Circle=�6/     	titleIcon#��[ 6=   �� 5�   "   $��Bagger��6,     	titleText#��[ 6:   5�      &   System.Windows.Controls.DataGrid  5�      $��1��6'   #   AutoGenerateColumns$# False��64   ���#243771���#ffffff$   ColumnHeaderHeight$$ 35Q�5�   S   %   GridLinesVisibility$
% None=�6k   &   	RowHeight$& 35Q�6�   '   RowBackground' �#243771(   HeadersVisibility$( Column=�5�   ?   )   CanUserAddRows$) False��6Z   *   CanUserDeleteRows$* False��6q   $��Stretch=�6�   $��Stretch=�6�   $��0 0 0 15q�6�   ��5�   P   �� *HistoricalData+��5�   <   Z� + � 	Resources+ 5�   "   *	  $System.Windows.Controls.DataGridCell, �� 
TargetType- �� Property. �� Value��%Y   '	        �� 5�   &   ", 	 6,   .�5�   *   �� - � ��$. 	10,0,10,0q�6D   5�   '   5�   #   /   ColumnHeaderStyle/ 5�   "   �� 5�   &   =
  7System.Windows.Controls.Primitives.DataGridColumnHeader", 
 6,   .�5�   *   �� - � ��. �#3d4c806G   �� 5�   *   - � ��. �#7f7cf16G   �� 5�   *   - � ��$. 25��6C   �� 5�   *   - � ��. 6H   Z� �� 5�   *   - � ��$. 12(�6E   �� 5�   *   - � ��$. SemiBold"�6G   5�   '   0   Columns0 5�   "   0  *System.Windows.Controls.DataGridTextColumn  5�   &   ,  &System.Windows.Controls.DataGridColumn1   Header$
1 Name��69   1  +System.Windows.Controls.DataGridBoundColumn2   Binding2 6G   �� *Name+  5�   &   $
1 Time��69   2 6G   �� *Time+  5�   &   $1 Value��69   2 6H   �� *Value+5�      5�      5�      5�      5�      5�      5�      5�      