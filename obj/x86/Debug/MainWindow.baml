   M S B A M L   `   `   `  ����P  LEduDemo.HuffmanCoding, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:EduDemo.HuffmanCodingEduDemo.HuffmanCoding  5   	   D @TLABS.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullD0clr-namespace:TLABS.WPF.About;assembly=TLABS.WPFTLABS.WPF.About 5   	   &     EduDemo.HuffmanCoding.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   4this#clr-namespace:EduDemo.HuffmanCoding     5   	   LTLABS.WPF.About0clr-namespace:TLABS.WPF.About;assembly=TLABS.WPF     5   	   -   5          J� SnapsToDevicePixels  .  � Title$ 
MainWindow��5   	   $	��700��6   $
��1000��6)    � WindowState$ 	Maximized=�66    � WindowStyle$
 None=�6N    � WindowStartupLocation$ CenterScreen=�6a    �� BitmapScalingMode$
 Fant=�6�    � Icon$= 7/EduDemo.HuffmanCoding;component/Images/EduDemoLogo.ico��6�    � 	Resources 5	         ControlButtonStyle �� 
TargetType	 �� Property
 �� Value �� Triggers P� Property P� Value N� EnterActions g� Duration	 W� To �� TargetProperty N� ExitActions��%�  &	        �� 5
   
   " ��6+   .�5      �� 	 �@J�Opacity$	
 1.0Q�6(   66    5      P� 5       �@J�IsMouseOver .  5      �� 5      .��5      �� .��5   "   W� $ 
00:00:0.15D�62   $ .9X�6H   $ Opacity�6P   6v   5      5       5      �� 5      .��5      �� .��5   "   W� $ 
00:00:0.15D�62   $ 1X�6H   $ Opacity�6O   6u   5      5      5      5      5       .��5"      � -   5        $��
LayoutRoot��5"      .+�5#   
   � ���	#FFF2F2F2 � ColumnDefinitions 5$      �� 5%      $	��350 �6#   61   �� 5&      $��3* �6#   60   .+�5)      �� -   5        $��	LeftPanel��5)      $	��350��6&   
���<��$
��Left=�6G   $��
-350,0,0,0q�6b   ._�5*      �  � RowDefinitions 5+      �� 5,      $��30 �6(   66   �� 5-      $��50 �6(   66   �� 5.      $
��Auto �6(   68   �� 5/      $��* �6(   65   �� 50      $��50 �6(   66   .+�53      �� -   5        $��WindowButtonPanel��53   !    �� Orientation$ 
Horizontal=�6:   $	��Top=�6S   $��Right=�6k   .+�54      �� -   5        $��btnMinimize��54   !     WindowButtonStyle#��[ 64   $��30��6_   $	��Top=�6k    �� Padding$ 	10,5,10,5q�6�   $��0,0,0,0q�6�    � ToolTip$ Minimize��6�   ._�55      F� +����        ��ا     ��ا �� �    �� 	$��10��6>   $��2��6I   $��0q�6T    �� Stretch$
 Fill=�6_   
�������
�������6�   56      �� 58      -   5        $��btnClose��58   !   #��[ 61   $��30��6\   $	��Top=�6h   $ 	10,5,10,5q�6�   $��0,0,0,0q�6�   $ Close��6�   ._�59      F� |���� 	= �� р��  z � $� �� р� 	= � � ��� р� $� � $� ��р��  � � 	= ��р�  $� � z ��� р�  	= � 	= �� 	$��10��6n   $��10��6y   $��0q�6�   $
 Fill=�6�   
�������
�������$��Center=�6�   6�   5:      5;      �� 5=      -   5        $��	txtHeader��5=       $��1��61   $��Huffman Coding Demo��6>   $��25(�6Y   
�������$��	200,0,0,0q�6z   $��Center=�6�    J� Opacity$ 0Q�6�   6�   �� 5>      -   5        $��iconHelp��5>      $��1��6,   $��Right=�69   $��Center=�6U   $��	0,0,200,0q�6p   $ 0Q�6�   $��20��6�   $��20��6�   $ What is Huffman Coding?��6�   $;��5/EduDemo.HuffmanCoding;component/Images/help_icon.png��6�    � Cursor$
 Hand��6  6J  �� 5A      -	   5        $��
InputPanel��5A   !   $��2��63   $��
20,20,20,5q�6@   $	��Top=�6T   $ 0Q�6l   .+�5B      �� $��Enter the text to encode��6$   $��13(�6D   
�������6g   � 5C      $��0,5,0,0q�6    5D      �� 5E   "   $��* �63   6?   �� 5F   "   $��30 �63   6@   .+�5I      �� -
   5        $��txtTextToEncode��5I   &   $��Center=�6=   ���	#26FFFFFF
�������$��1q�6�   
������� �� 	MaxLength$	 100��6�   6�   �� 5J      -   5        $��	btnEncode��5J   %   $��1��66   $��Center=�6F   ���	#26FFFFFF
�������$��0,1,1,1q�6�   $
 Hand��6�   $ Go��6�   ��6�   �� *ActualHeight+ �� ElementName$ txtTextToEncode��._�5K   "   F� =����@T� ��[ р�� ��[ ���!��� р�� ��O�@T� ��Oр�� ��� 	$��10��6R   $��12��6]   $
 Fill=�6i   ���	#FFFFFFFF6�   5L      5M      5N      � 5P      -   5        $��ResultPanel��5P   (   $��3��6   $��	20,5,20,5q�6;   }�. $ 0Q�6b    5Q      �� 5R      $��30 �6,   6:   �� 5S      $��* �6,   69   .+�5V      �� $��Result��6$   $��Center=�62   
�������$��18(�6`   $
��Bold"�6n   6�   �� 5W      $ 
Horizontal=�6%   $��Right=�6>   .+�5X      �� -   5        $��btnSwipeResultLeft��5X   %   $��30��6?   $��30��6J   
������ $
 Hand��6o   ._�5Y   "   F� =������� ��[ �@T� ��� р�� ��O�@T� ��O� 	= ��� �@T� ��[ 	$��10��6P   $��12��6[   $
 Fill=�6g   ���	#FFFFFFFF6�   5Z      �� 5[      -   5        $��btnSwipeResultRight��5[   %   $��30��6@   $��30��6K   
������ $
 Hand��6p   ._�5\   "   F� =����@T� ��[ р�� ��[ ���!��� р�� ��O�@T� ��Oр�� ��� 	$��10��6R   $��12��6]   $
 Fill=�6i   ���	#FFFFFFFF6�   5]      5^      � 5`      -   5        $��
ResultGrid��5`      $��1��61   $	��620��6>   $
��Left=�6J    5a      �� 5b   "   $	��310 �63   6A   �� 5c   "   $	��310 �63   6A    5f      �� 5g   "   $��30 �60   6>   �� 5h   "   $��* �60   6=   .+�5k      �� $��Encoded data��6(   $��Center=�6<   ���	#FFD6D6D6$��15(�6n   $
��Bold"�6|   6�   �� 5l      $��1��6+   $
��Auto=�68   .��5m   "   �� $	��Top=�6.   .+�5n   &   �� -   5        $��txtEncodedData��5n   0   ���	#FFF6F6F6$��18(�6]   $
��Bold"�6k   $
��Wrap=�6}   6�   �� 5o   &   ���	#FFF6F6F6$��13(�6G   $
��Wrap=�6U   $&  Compared to 8 bit ASCII encoding��6i   �� 5p   *   $�Compression ratio: ��6.   6K    �� 5q   *   -   5         �Name$ txtCompressionRatio��5q   .   ���	#FFFFFFFF$
��Bold"�6`   6t   5r   '   5s   #   5t      �� 5v      $��Encoding��6(   $��1��68   $��Center=�6H   ���	#FFD6D6D6$��15(�6z   $
��Bold"�6�   6�   � 5w      $��1��6#   $��1��60   $��30��6@   $	��Top=�6L    5x   "   �� 5y   &   $��* �67   6C   �� 5z   &   $��* �67   6C   �� 5{   &   $��* �67   6C   .+�5}   "   �� $��0��6)   ���	#D0FFFFFF$��.5q�6P   ._�5~   &   �� $��5,0,0,0q�60   $��Center=�6A   
���<��$��15(�6q   $
��Bold"�6   $��	Character��6�   6�   5   #   �� 5�   "   $��1��6)   ���	#D0FFFFFF$��.5q�6P   ._�5�   &   �� $��5,0,0,0q�60   $��Center=�6A   
���<��$��15(�6q   $
��Bold"�6   $��	Frequency��6�   6�   5�   #   �� 5�   "   $��2��6)   ���	#D0FFFFFF$��.5q�6P   ._�5�   &   �� $��5,0,0,0q�60   $��Center=�6A   
���<��$��15(�6q   $
��Bold"�6   $��Encoding��6�   6�   5�   #   5�      �� 5�      $��1��6+   $��1��68   $
��Auto=�6H   $��0,30,0,0q�6k   $��0q�6}   .��5�   "   � -   5        $��EncodingGrid��5�   '    5�   &   �� 5�   *   $��* �6;   6G   �� 5�   *   $��* �6;   6G   �� 5�   *   $��* �6;   6G   5�   #   5�      5�      5�      �� 5�      -   5        $��imgLogo��5�      $��4��6+   $��Right=�68   $	��300��6T   $��	25,5,25,5q�6`   $A��;/EduDemo.HuffmanCoding;component/Images/EduDemoAndTLABS.png��6s   $ 0Q�6�   $
 Hand��6�   6  5�      5�      � 5�      -   5        $��
CanvasGrid��5�      $��1��6%   }�. 
������ .+�5�      �� -   5        $��
canvasTree��5�      $	��200��6+   $	��200��67   $	��100��6D   $	��100��6S   $��Center=�6c   $��Center=�6~    � LayoutTransform 5�      V� 5�      .~�5�      �� -   5        canvasTreeST�� �� CenterX$	 0.5Q�5�   )     �� CenterY$	  0.5Q�67   ! �� ScaleX! 5�   )   �� *Value+$ sliderCanvasScale��" �� ScaleY" 5�   )   �� *Value+$ sliderCanvasScale��5�   G   5�      z�5�      T� 5�      -   5        canvasTreeTT��# T� X$# 0Q�5�   C   $ T� Y$$ 0Q�6I   6R   5�      �� 5�      -   5        $��TopBar��5�      $
��Auto��6'   $	��Top=�65   ���	#A6E0E0E0$ 0Q�6d   ._�5�      �� .+�5�      �� ���	#A6D6D6D6._�5�      �� $��PRIORITY QUEUE��6(   $��16(�6>   $
��Bold"�6L   
���<��$��	20,5,20,5q�6s   6�   5�      � 5�      -   5        $��wp_NC2��5�   $   % � Orientation$% 
Horizontal=�62   $��
20,5,20,10q�6K   6a   5�      5�      �� 5�      -   5        $��
ControlBar��5�      $��60��6+   $��Bottom=�67   ���	#A6C0C0C0$��	0,0,0,-60q�6i   $y�Hidden=�6|   ._�5�      �  5�      �� 5�      $	��100 �6/   6=   �� 5�      $��* �6/   6;   �� 5�      $	��100 �6/   6=   .+�5�      �� -   5        $��btnPlayPause��5�   !   #��[  65   $��Center=�6a   $��Right=�6|   $��0,0,10,0q�6�   $
 Hand��6�   
������ ._�5�      �� -   5        $��imgPlayPause��5�   $   $��40��68   $��40��6C   $
 Play��6O   $;��5/EduDemo.HuffmanCoding;component/Images/icon_play.png��6^   6�   5�      �� 5�      -   5        $��btnStop��5�   !   #��[  60   $��Center=�6\   $��Right=�6w   $��0,0,60,0q�6�   $
 Hand��6�   
������ $y�	Collapsed=�6�   ._�5�      �� -   5        $��imgStop��5�   $   $��16��63   $��16��6>   $
 Stop��6J   $;��5/EduDemo.HuffmanCoding;component/Images/icon_stop.png��6Y   6�   5�      �� 5�      -   5        $��sliderTimeline��5�   !   $��1��67   
������ 6�   �� 5�      -    5        $��txtTime��5�   $   $��2��63   $��Center=�6C   $��16(�6^   $
��Bold"�6l   
���<��6�   5�      5�      �� 5�      -!   5        $��	ToolPanel��5�      $	��Top=�6.   $��Right=�6F   $��
0,100,20,0q�6b   $	 0.2Q�6v   .+�5�      �� $��50��6   $��25��6(   ���	#A6B6B6B6$��0,0,0,1q�6K   & �� CornerRadius$& 3,3,0,0��6\   ._�5�      �� $ 
Horizontal=�6%   $��Center=�6>   $��Center=�6[   .+�5�      �� -"   5        $��toolMove��5�   %   
������ $ 2q�6N   $��Center=�6Z   $ 	Move tool��6u   $	 0.5Q�6�   $
 Hand��6�   ._�5�   "   �� $��16��6(   $��16��63   $;��5/EduDemo.HuffmanCoding;component/Images/move_tool.png��6?   6�   5�      �� 5�      -#   5        $��toolZoom��5�   %   
������ $ 2q�6N   $��Center=�6Z   $ 	Zoom tool��6u   $	 1.0Q�6�   $
 Hand��6�   ._�5�   "   �� $��16��6(   $��16��63   $;��5/EduDemo.HuffmanCoding;component/Images/zoom_tool.png��6?   6�   5�      5�      5�      �� 5�      $��50��6   $	��120��6)   ���	#A6C6C6C6$& 0��6M   ._�5�      �� -$   5        $��sliderCanvasScale��5�   !   $ Zoom Canvas��6:   ' �� Orientation$' Vertical=�6P   $��Center=�6g   $��Center=�6�   $	��100��6�   $��50��6�   ( � Minimum$	( 0.1Q�6�   ) � Maximum$) 3Q�6�   * � Value$* 1Q�6�   6�   5�      �� 5�      $��50��6   $��25��6(   ���	#A6D6D6D6$��0,0,0,0q�6K   $& 0,0,0,0��6\   ._�5�      �� -%   5        $��imgFitGraph��5�       $! Fit the graph into viewport��63   $
 Hand��6Y   $��3q�6g   $:��4/EduDemo.HuffmanCoding;component/Images/fit_tool.png��6r   6�   5�      �� 5�      $��50��6   $��25��6(   ���	#A6B6B6B6$��0,0,0,0q�6K   $& 0,0,3,3��6\   ._�5�      �� -&   5        $��txtCanvasScale��5�   $   $
��100%��6:   $��Center=�6F   $��Center=�6a   ���	#FF3636366�   5�      5�      5�      5�      0  *TLABS.WPF.About.AboutTLABSAnimationControl  5�   
   -'   5        +  Name$+ AC_AboutTLABS��5�   5   , K� ZIndex$	, 100��6L   6a   5�      5�      