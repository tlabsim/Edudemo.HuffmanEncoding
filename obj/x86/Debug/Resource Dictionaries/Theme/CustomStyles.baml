   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5      1&clr-namespace:System;assembly=mscorlibSystem  5      a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35N;clr-namespace:System.Windows;assembly=PresentationFrameworkSystem.Windows 5	      Q MTLABS.IntelligentInput, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:TLABS.IntelligentInput;assembly=TLABS.IntelligentInputTLABS.IntelligentInput 5
      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089  �� MergedDictionaries �� Source2   ,System.Windows.Media.Animation.QuadraticEase   QEaseOut7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode  QEaseIn �� 
TargetType  LoginButtonStyle �� Property �� Value  
GrayBrush7  TextBoxBorderBrush  ContentFontSize �� 
TargetType'  !System.Windows.VisualStateManager   VisualStateGroups%  System.Windows.VisualStateGroup   States   System.Windows.VisualState	   
Storyboard
 �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value ��Name �� CornerRadius �� 
StartPoint �� EndPoint � Color � Offset J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   ShadowDepth   Opacity   
BlurRadius ��Name  ControlsDisabledBrush J� IsHitTestVisible J� Opacity �� RadiusY �� RadiusX $  TextBoxMouseOverInnerBorderBrush  TextBoxMouseOverBorderBrush ��Name �� ClearTypeHint 	 LoginMenuRadioButtonStyle&   System.Windows.Media.TextOptions ��Name  �� Triggers! ]� 
Conditions" �� Property# �� Value$ N� EnterActions% W� EasingFunction& g� 	BeginTime	' W� To( g� Duration) N� ExitActions* P� Property+ P� Value, �� EasingFunction	- �� To 
 LoginMenuRadioButtonStyle2�� 5      D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    :x,http://schemas.microsoft.com/winfx/2006/xaml     5      .sys&clr-namespace:System;assembly=mscorlib  5      1System&clr-namespace:System;assembly=mscorlib  5      8d2http://schemas.microsoft.com/expression/blend/2008  5      Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5      UthemesJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero  5      YPresentationOptionsAhttp://schemas.microsoft.com/winfx/2006/xaml/presentation/options  5      Cvsm;clr-namespace:System.Windows;assembly=PresentationFramework  5	      OiInputDclr-namespace:TLABS.IntelligentInput;assembly=TLABS.IntelligentInput  5
        5      �� 5   
   $ Brushes.xaml?�6   �� 5   
   $ 
Fonts.xaml?�6   %�  &	        &	 &     &	 K     7  7  7  7  7  7  &		 �
    7   7   7   7   7   7   &	
     7   7   7   7   7   7      5      $ EaseOut=�6%   6<      5      $ EaseIn=�6$   6:   �� 5      " ��6   .�5   
   ��  �@J�SnapsToDevicePixels . 5      �� 5   
    � ��8   5      �� 5   
    � ��8  5      �� 5   
    � �� �	#FF5555555      �� 5    
    � ��8  5!      �� 5"   
    � ��$
 Bold"�5#      �� 5$   
    � ��$ 	10,4,10,4q�5%      �� 5&   
    � ��$ 1q�5'      �� 5(   
    � �� 5)      �� 5*      " ��6"   .R�5+      �  5,        5-      CommonStates��. 5.   "     
Normal��62     5/   "   	MouseOver��.	 50   &   �� .��51   *   U� $
 (UIElement.Opacity)�6H   $ MouseOverBorder��52   H   .\�53   .     $ 0��6C   $ 1Q�54   C   55   +   56   '   57   #     58   "   Pressed��.	 59   &   �� .��5:   *   U� $
 (UIElement.Opacity)�6H   $ PressedBorder��5;   H   .\�5<   .     $ 0��6C   $ 1Q�5=   C   5>   +   5?   '   5@   #     5A   "   Disabled��.	 5B   &   �� .��5C   *   U� $
 Opacity�6H   $ DisabledVisualElement��5D   H   .\�5E   .   �� $ 0��6C   $	 0.7Q�5F   C   5G   +   U� 5H   *   $
 (UIElement.Opacity)�6H   $ contentPresenter��5I   H   .\�5J   .     $ 0��6C   $	 0.3Q�5K   C   5L   +   5M   '   5N   #   5O        5P      FocusStates��. 5Q   "     Focused��.	 5R   &   �� .��5S   *   U� $
 (UIElement.Opacity)�6H   $ FocusRectangle��5T   H   .\�5U   .     $ 0��6C   $ 1Q�5V   C   5W   +   U� 5X   *   $
 (UIElement.Opacity)�6H   $ FocusInnerRectangle��5Y   H   .\�5Z   .     $ 0��6C   $ 1Q�5[   C   5\   +   5^   '   5_   #     5`   "   	Unfocused��62   5a      .+�5c      �� $ 
Background��6!   ���	#FF666666$��1q�5e   !   $ 0��5f   !   ��5g      �� 5h   "   $ 0.5,0&�66   $ 0.5,1&�6I   .��5i   &   � $ 	#FFD6D6D6��63   $ 0Q�6E   � 5j   &   $ 	#FFC6C6C6��63   $ 1Q�6E   5k   #    5m        5n   "   $ 0Q�63   $ .2Q�6C   $ 5Q�6P   6a   5p      �� 5q      $ DisabledVisualElement��6$   8��  .  $ 0Q�5t   $   $ 0��5u   $   $ 0��5v   $   �� 5w      $ MouseOverBorder��6!   ���	#FFB6B6B6$��1q�5y   !   $ 0��5z   !   $ 0Q�5{   !   �� 5|      $ PressedBorder��6!   ���	#FFA6A6A6#��z��5~   !   $ 0��5   !   $ 0Q�5�   !   �� 5�      $ FocusRectangle��6$   8�� $ 0��5�   $   $ 0��5�   $   $��-1q�5�   $   $ 0Q�5�   $   �� 5�      $ FocusInnerRectangle��6$   $��1��5�   $   8�� $ 0��5�   $   $ 0��5�   $   $ 0Q�5�   $   �� 5�      $ contentPresenter��6+   #��z��5�   +   #��z��5�   +   #��z��5�   +   #��z��5�   +   #��z��5�   +   $ Enabled=�5�   +   5�      5�      5�      5�      �� 5�      " 	�6.   .�5�   
   ��  �@�OverridesDefaultStyle . 6A   �� 5�   
    �@J�SnapsToDevicePixels . 5�      �� 5�   
    � �� �	#FF8080805�      �� 5�   
    � ��
 �����5�      �� 5�   
    � ��$ 0q�5�      �� 5�   
    � ��
 ���� 5�      �� 5�   
    � ��$ 14(�5�      �� 5�   
    �@ TextHintingMode$ Animated=�5�      �� 5�   
    � ��$ Center=�5�      �� 5�   
    � ��$ Center=�5�      �� 5�   
    � ��$ 5q�5�      �� 5�   
    � ��$ 0,1,0,1q�5�      �� 5�   
    �@�Cursor$
 Hand��5�      �� 5�   
    �@J�Opacity$ 1Q�5�      6   �� 5�   
    � �� 5�      �� 5�      " 	�6"   .R�5�      � .+�5�      �� $ BackgroundBorder��6!   #��z��6;   #��z��6e   #��z��6�   $ 5,0,0,5��6�   ._�5�      �� $ ContentContainer��6-   $��Center=�5�   )   #��z��5�   )   .��5�   "   �� $ contentPresenter��63   #��z��5�   /   #��z��5�   /   #��z��5�   /   #��z��5�   /   #��z��5�   /   $ Enabled=�5�   /   5�      5�      5�        5�      ]� 5�      ! 5�      �� 5�   "   " �@J�IsMouseOver# . 6R   �� 5�   "   " �@d�	IsChecked$# FalseY�6A   6Q   $ 5�      �� 5�   "   .��5�   &   �� .��5�   *   W� 8%   $
 Opacity�5�   >   $& 0:0:0X�5�   >   $' .8X�5�   >   $( 0:0:0.25D�6F   5�   '   5�   #   ) 5�      �� 5�   "   .��5�   &   �� .��5�   *   W� 8%  $
 Opacity�5�   >   $& 0:0:0X�5�   >   $	' 1.0X�5�   >   $( 0:0:0.25D�6G   5�   '   5�   #   5�      P� 5�      * �@d�	IsChecked$
+ TrueY�67    �5�      �� 5�   "    �@J�Opacity$ 1Q�6<   $ 5�      �� 5�   "   .��5�   &   �� .��5�   *   �� 8,  $*
 $(Background).(SolidColorBrush.Color)�5�   >   $- 	#80FFFFFFX�5�   >   $( 0:0:0.25D�6M   �� 5�   *   8,  $*
 $(Foreground).(SolidColorBrush.Color)�5�   >   $- 	#FF01152BX�5�   >   $( 0:0:0.25D�6M   5�   '   5�   #   ) 5�      �� 5�   "   .��5�   &   �� .��5�   *   �� 8,  $*
 $(Background).(SolidColorBrush.Color)�5�   >   $- 	#FF808080X�5�   >   $( 0:0:0.25D�6M   �� 5�   *   8,  $*
 $(Foreground).(SolidColorBrush.Color)�5�   >   $- WhiteX�5�   >   $( 0:0:0.25D�6I   5  '   5  #   5     5     5     5	     �� 5     " 	�6/   .�5  
   ��  �@�OverridesDefaultStyle . 6A   �� 5  
    �@J�SnapsToDevicePixels . 5     �� 5  
    � �� �	#FF8080805     �� 5  
    � ��
 �����5     �� 5  
    � ��$ 0q�5     �� 5  
    � ��
 ���� 5     �� 5  
    � ��$ 14(�5     �� 5  
    �@ TextHintingMode$ Animated=�5     �� 5  
    � ��$ Center=�5     �� 5  
    � ��$ Center=�5     �� 5  
    � ��$ 5q�5      �� 5!  
    � ��$ 0,1,0,1q�5"     �� 5#  
    �@�Cursor$
 Hand��5$     �� 5%  
    �@J�Opacity$ 1Q�5&     6   �� 5'  
    � �� 5(     �� 5)     " 	�6"   .R�5*     � .+�5+     �� $ BackgroundBorder��6!   #��z��6;   #��z��6e   #��z��6�   $ 5,0,0,5��6�   ._�5,     �� $ ContentContainer��6-   $��Center=�5-  )   #��z��5.  )   .��5/  "   �� $ contentPresenter��63   #��z��50  /   #��z��51  /   #��z��52  /   #��z��53  /   #��z��54  /   $ Enabled=�55  /   56     57     58       59     ]� 5:     ! 5;     �� 5<  "   " �@J�IsMouseOver# . 6R   �� 5=  "   " �@d�	IsChecked$# FalseY�6A   6Q   $ 5?     �� 5@  "   .��5A  &   �� .��5B  *   W� 8%   $
 Opacity�5D  >   $& 0:0:0X�5E  >   $' .8X�5F  >   $( 0:0:0.25D�6F   5G  '   5H  #   ) 5J     �� 5K  "   .��5L  &   �� .��5M  *   W� 8%  $
 Opacity�5O  >   $& 0:0:0X�5P  >   $	' 1.0X�5Q  >   $( 0:0:0.25D�6G   5R  '   5S  #   5U     P� 5V     * �@d�	IsChecked$
+ TrueY�67    �5W     �� 5X  "    �@J�Opacity$ 1Q�6<   $ 5Z     �� 5[  "   .��5\  &   �� .��5]  *   �� 8,  $*
 $(Background).(SolidColorBrush.Color)�5^  >   $- 	#FFFFFFFFX�5_  >   $( 0:0:0.25D�6M   �� 5`  *   8,  $*
 $(Foreground).(SolidColorBrush.Color)�5a  >   $- 	#FF01152BX�5b  >   $( 0:0:0.25D�6M   5c  '   5d  #   ) 5f     �� 5g  "   .��5h  &   �� .��5i  *   �� 8,  $*
 $(Background).(SolidColorBrush.Color)�5k  >   $- 	#FF808080X�5l  >   $( 0:0:0.25D�6M   �� 5m  *   8,  $*
 $(Foreground).(SolidColorBrush.Color)�5o  >   $- WhiteX�5p  >   $( 0:0:0.25D�6I   5r  '   5s  #   5u     5w     5y     5z     5|     