   M S B A M L   `   `   `  ����?  ;Cars, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:Cars.Views
Cars.Views  5   	   1clr-namespace:Cars.ViewModelsCars.ViewModels  5   	       Cars.Views.MainView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:Cars.Views     5   	   3	viewmodelclr-namespace:Cars.ViewModels     5   	     � Title$  MainView��5	   	   $	��450��6   $	��820��6'   .��5
      �  � RowDefinitions 5   
   �� 5      $��6* �6   6*   �� 5      6   .+�5   
   �� ��6   �� *Cars+ �� UpdateSourceTrigger$ PropertyChanged=� �� Mode$ TwoWay=���5      �� 5      .R�5      �� 
�������$	��750��6/   $	��150��6;    �� Orientation$ 
Horizontal=�6H   .+�5      �� $��15q�6   $	��120��6(   $	��120��64   ��5      �� 5   "    �� DecodePixelWidth$	 300��6.    �� 	UriSource 6E   �� *Image+5      �� 5      .+�5      �� $��Right=�6    $��30(�6<   $
��Bold"�6J   .��6\   	Model :6e   �� 5      $��Right=�6    $��30(�6<   $
��Bold"�6J   .��6\   
Vendor :6f   �� 5      $��Right=�6    $��30(�6<   $
��Bold"�6J   .��6\   Year :6d   5      �� 5      $��Center=�6!   .+�5      �� $��5q�6"   $	��200��6-   $��26(�69   ��6G   �� *Model+6`   �� 5      $��5q�6"   $	��200��6-   $��26(�69   ��6G   �� *Vendor+6a   �� 5       $��5q�6"   $	��200��6-   $��26(�69   ��6G   �� *Year+6_   5!      5"      5#      5%      �� 5&   
   $��1��6   $ 
Horizontal=�6"   $��Center=�6;   .+�5'      �� $��5q�6   $
��Bold"�6    $��26(�62   .��6@   Multi6G   d� 5(      $��10q�5)       )  %MaterialDesignSwitchLightToggleButton#��[  5*       � ToolTip$+ %MaterialDesignSwitchLightToggleButton��5+       d� 	IsChecked 5,      �� *Single+$ PropertyChanged=�$ TwoWay=��� 5-      $��5q�6   $
��Bold"�6   $��26(�61   .��6?   Single6G   �� 5.      $��	40,4,0,12q�6   $
��Bold"�6'   $��26(�69   .��6G   Time:6N   �� 5/      $	��200��6   $��26(�6$   $��	0,10,20,8q�62   ��6E   �� *Timer+$ PropertyChanged=�$ TwoWay=�6�   �� 50      $��15,0,0,0q�6   $	��100��6'   $��26(�63   $��45��6A   $
��Bold"�6M   ��6_   �� *StartCommand+.��6�   Start6�   �� 51      $��5,0,0,0q�6   $	��110��6&   $��26(�62   $��45��6@   $
��Bold"�6L   ��6^   �� *CancelCommand+.��6�   Cancel6�   52      53      54      