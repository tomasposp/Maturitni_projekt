   M S B A M L   `   `   `  ����F  BMat_projekt, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:Mat_projektMat_projekt  5   	       Mat_projekt.NabojovyMode   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:Mat_projekt     5   	     � Title$  NabojovyMode��5   	   $	��450��6   $	��800��6+    � 
ResizeMode$ NoResize=�67   .��5	      � .+�5
   
   �� $��Pictures/background2.png��6   $
��Fill=�62   � 5   
   -   5        $��mrizka��5      $��240,70,243,29q�6   ��5      �� 5       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   5      5      �� 5   
   -   5        $��Naboje��5      $��Center=�6   $��30��6;   $��345,25,324,366q�6G   $��Center=�6_   $	��125��6z   �� 5   
   -   5        $��MainMenu��5      $
��Left=�6    $��26��6;   $��660,383,0,0q�6G   $	��Top=�6\   $��80��6t   $��Pictures/long.png��6�   $
��Fill=�6�    K� ZIndex$	 999��6�   �� 5   
   -   5        $��	Main_Menu��5      $��Hlavní Menu��6!   $
��Left=�67   $��660,385,0,13q�6R   $��Center=�6�   $��23��6�   $��80��6�   $��10(�6�   $��Center=�6�   $��Center=�6�   $	 999��6	  �� 5   
   -   5        $��ScoreLBL��5      $��Skóre:��6    $
��Left=�61   $��30��6L   $��
525,10,0,0q�6X   $	��Top=�6l   $	��130��6�   �� 5   
   -   5        $��RadarImg��5      $
��Left=�6    $��26��6;   $��	95,70,0,0q�6G   $	��Top=�6Z   $��80��6r   $��Pictures/long.png��6�   $
��Fill=�6�   �� 5   
   -   5        $��RadarLbl��5      $��Radar (300)��6    $
��Left=�66   $��26��6Q   $��95,70,0,325q�6]   $��Center=�6r   $��90��6�   6�   �� 5   
   -   5        $��AirstrikeImg��5      $
��Left=�6$   $��26��6?   $��
95,110,0,0q�6K   $	��Top=�6_   $��80��6w   $��Pictures/long.png��6�   $
��Fill=�6�   �� 5   
   -	   5        $��AirstrikeLbl��5      $��Airstrike (400)��6$   $
��Left=�6>   $��26��6Y   $��95,110,0,285q�6e   $��Center=�6{   $��90��6�   6�   �� 5   
   -
   5        $��	NabojeImg��5      $
��Left=�6!   $��26��6<   $��
95,150,0,0q�6H   $	��Top=�6\   $��80��6t   $��Pictures/long.png��6�   $
��Fill=�6�   �� 5   
   -   5        $��	NabojeLbl��5      $��Náboje (500)��6!   $
��Left=�68   $��26��6S   $��95,150,0,245q�6_   $��Center=�6u   $��90��6�   6�   � 5   
   -   5        $��FinalniScoreGrid��5       J� Opacity$ 0Q�6'   $y�Hidden=�63   .+�5      �� -   5        $��FinalniScoreImg��5      $��/Pictures/EndingScore.png��6+   $��0,0,-1,0q�6N   $
��Fill=�6`    J� RenderTransformOrigin$ 0.5,0.5&�6o   z�5"      V� 5#      .~�5$      �� �� 5%       �� AngleY$ 0.071Q�6(   �� 5&      T� 5'       T� Y$ 0.628Q�6-   5)      5+      �� 5,      -   5        $��FinalniScoreLBL��5,      $�� ��6+   $��Center=�66   $��30��6S   $��	150,0,0,0q�6_   $��Center=�6r   $	��600��6�   $��Stencil)�6�   $��20(�6�   5-      50      51      