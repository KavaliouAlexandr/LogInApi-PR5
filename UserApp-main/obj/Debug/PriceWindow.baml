   M S B A M L   `   `   `  ����B  >UserApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:UserAppUserApp  5   	       UserApp.PriceWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:UserApp     5   	   _ [MaterialDesignThemes.Wpf, Version=4.5.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	     � Title$  	Users app��5	   	   $	��600��6   $	��600��6(   .��5
      � ���	#ffdadada.+�5   
   �� $	��400��6   $��15q�6    
�������$��Center=�6?    �� Padding$ 30q�6Z   $	��550��6g    �� CornerRadius$ 20��6v    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         
BlurRadius$ 30Q�6#      Color$ 	LightGray��63      ShadowDepth$ 0Q�6E   ._�5      �� .+�5      � $��0 0 0 20q�6   .+�5      �� $��Available tickets��6    $��30(�69   $
��Bold"�6G   �� 5      -   5        $��Right=�5      $
��Back��69      MaterialDesignFlatButton#��[  6[   5      �� 5       �� TextAlignment$ Center=�6   $��You selected:��63   $��17(�6H   � 5      $��0 10 0 0q�6   .+�5      �� -   5         ��Name$ selectedFrom��5       $��
KRK Krakow��66   $��	0 0 140 0q�6H   $ Center=�6[   $��15(�6r   $
��Bold"�6�   �� 5      -   5        $ 
selectedTo��5       $��
WAW Warsaw��64   $��	140 0 0 0q�6F   $ Center=�6Y   $��15(�6p   $
��Bold"�6~   �� 5      -   5        $ selectedDeparture��5       $��11:00 18.06.2022��6;   $��
0 17 140 0q�6S   $ Center=�6g   �� 5      -   5        $ selectedArrival��5       $��12:05 18.06.2022��69   $��
140 17 0 0q�6Q   $ Center=�6e   '  !MaterialDesignThemes.Wpf.PackIcon  5      	   Kind$	 ArrowRightBoldBox=�6.   $��0 11 0 0q�6G   $��Center=�6Y   5      �� 5      -   5        $ countTickets��5      $��Select cabin class:��62   $
��0 10q�6M   $��17(�6[   $ Center=�6i   � 5      $
��0 10q�6   .+�5        $	 	AlphaEBox=�6.   �� 5      $��15 0 0 0q�6    conom class:6@   �� 5       -   5        $ ecoavail��5        $��	155 0 0 0q�62   $��Unavailable��6E   �� 5!      $��	280 0 0 0q�6    Price:6;   �� 5"      -   5        $ ecoprice��5"       $��	320 0 0 0q�62   $��0$��6E   �� 5#      -	   5        
 ��Name$
 ecobtn��5#      $��0,-8,0,8q�6-   $��Right=�6?   {�.  $	��Buy��6m   6{   5$      � 5%      $
��0 10q�6   .+�5&        $	 	AlphaPBox=�6.   �� 5'      $��15 0 0 0q�6    remium econom:6B   �� 5(      -
   5        $ 	premavail��5(       $��	155 0 0 0q�63   $��Unavailable��6F   �� 5)      $��	280 0 0 0q�6    Price:6;   �� 5*      -   5        $ 	premprice��5*       $��	320 0 0 0q�63   $��0$��6F   �� 5+      -   5        $
 prembtn��5+      $��0,-8,0,8q�6.   $��Right=�6@   {�.  $	��Buy��6n   6|   5,      � 5-      $
��0 10q�6   .+�5.        $	 	AlphaBBox=�6.   �� 5/      $��15 0 0 0q�6    usiness class:6B   �� 50      -   5        $ busavail��50       $��	155 0 0 0q�62   $��Unavailable��6E   �� 51      $��	280 0 0 0q�6    Price:6;   �� 52      -   5        $ busprice��52       $��	320 0 0 0q�62   $��0$��6E   �� 53      -   5        $
 busbtn��53      $��0,-8,0,8q�6-   $��Right=�6?   {�.  $	��Buy��6m   6{   54      � 55      $
��0 10q�6   .+�56        $	 	AlphaFBox=�6.   �� 57      $��15 0 0 0q�6    irst class:6?   �� 58      -   5        $ 	frstavail��58       $��	155 0 0 0q�63   $��Unavailable��6F   �� 59      $��	280 0 0 0q�6    Price:6;   �� 5:      -   5        $ 	frstprice��5:       $��	320 0 0 0q�63   $��0$��6F   �� 5;      -   5        $
 frstbtn��5;      $��0,-8,0,8q�6.   $��Right=�6@   {�.  $	��Buy��6n   6|   5<      5=      5>      5?      5@      