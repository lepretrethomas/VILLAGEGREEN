   M S B A M L   `   `   `  ����C  ?Maquette, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MaquetteMaquette  5   	       Maquette.FicheProduit   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=2.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   Y UXceed.Wpf.DataGrid, Version=2.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5   	   "localclr-namespace:Maquette  5   	     � Title$  FicheProduit��5
   	   $	��480��6   $	��720��6+   .��5      � .+�5   
   �� -   5         ��Name$ label1��5      $��Référence Produit :��6    $
��Left=�6>   $��	72,47,0,0q�6Y   $	��Top=�6l   $��32(�6�   �� 5   
   -   5         ��Name$ btn_quitter��5      $��Quitter��6&   $
��Left=�68   $��
37,410,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ btn_annuler��5      $��Annuler��6&   $
��Left=�68   $��605,410,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $ btn_modifier��5      $��Modifier��6'   $
��Left=�6:   $��505,410,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5        $ btn_supprimer��5      $��	Supprimer��6(   $
��Left=�6<   $��403,410,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5         ��Name$ VG_logo_mini_jpg��5      $��0,0,673,391q�6*   $��Z-VG_logo_mini.jpg��6?   $
��Fill=�6[   �� 5   
   -   5        $ label5��5      $��#####��6    $
��Left=�60   $��
361,48,0,0q�6K   $	��Top=�6_   $��32(�6w   $	��139��6�   �� 5   
   -   5         ��Name$ groupBox��5      $��Photos��6%   $
��Left=�65   $��83��6P   $��
559,19,0,0q�6\   $	��Top=�6p   $	��123��6�   .��5      �� -	   5        $ button��5      $��+��6%   $
��Left=�61   $��24��6L   $��91,42,-5,-5q�6X   $	��Top=�6m   $��25��6�   5      �� 5   
   -
   5        $ image��5      $
��Left=�6   $��52��6:   $��
570,41,0,0q�6F   $	��Top=�6Z   $��69��6r   �� 5   
   -   5         ��Name$ 
tabControl��5      $
��Left=�6)   $	��293��6D   $��
40,108,0,0q�6Q   $	��Top=�6e   $	��638��6}   .@�5      �� $��
Descriptif��6   .��5      � ���	#FFE5E5E5.+�5      �� -   5        $ label��5      $��Rubrique��6+   $��Right=�6>   $��	0,9,522,0q�6Z   $	��Top=�6m   �� 5      -   5        $ label2��5      $��Libellé court��6,   $��Right=�6D   $��
0,92,521,0q�6`   $	��Top=�6t   �� 5      -   5        $ label8��5      $��Nom du produit��6,   $
��Left=�6E   $��	17,46,0,0q�6`   $	��Top=�6s   �� 5      -   5         ��Name$ textBox6��5      $
��Left=�60   $��23��6K   $��
121,49,0,0q�6W    �� TextWrapping$
 Wrap=�6k   $��
PRODUITPRO��6   $	��Top=�6�   $	��480��6�   �� 5      -   5         ��Name$ comboBox��5      $
��Left=�61   $��
122,13,0,0q�6L   $	��Top=�6`   $	��150��6x   .@�5      �� -   5        $	��cb1��5   '   .��62   
Rubrique A6>   �� 5       -   5        $	��cb2��5    '   .��62   
Rubrique B6>   �� 5!      -   5        $	��cb3��5!   '   	 �� 
IsSelected	 . .��6D   
Rubrique C6P   5"      �� 5#      -   5        $ label9��5#      $��Sous-rubrique��6,   $
��Left=�6D   $��	310,9,0,0q�6_   $	��Top=�6r   
 J� RenderTransformOrigin$
 0.202,-0.299&�6�   �� 5$      -   5        $ 	comboBox1��5$      $
��Left=�62   $��
407,13,0,0q�6M   $	��Top=�6a   $	��194��6y   .@�5%      �� -   5        $
��cbi1��5%   '   .��63   Sous-rubrique x6D   �� 5&      -   5        $
��cbi2��5&   '   	 . .��6E   Sous-rubrique y6V   �� 5'      -   5        $
��cbi3��5'   '   .��63   Sous-rubrique z6D   5(      �� 5)      -   5        $ label3��5)      $��Libellé long��6,   $
��Left=�6C   $��
40,161,0,0q�6^   $	��Top=�6r   �� 5*      -   5        $ textBox1��5*      $
��Left=�60   $��41��6K   $��
120,97,0,0q�6W   $
 Wrap=�6k   $2��,LibCLibCLibCLibCLibCLibCLibCLibCLibCLibCLibC��6   $	��Top=�6�   $	��482��6�   �� 5+      -   5        $ textBox2��5+      $
��Left=�60   $��90��6K   $��120,163,0,0q�6W   $
 Wrap=�6l   $����LibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibLLibL��6�   $	��Top=�6  $	��481��64  5,      5-      �� 5.      $��Détail��6   .��5/      � ���	#FFE5E5E5.+�50      �� -   5        $ 	groupBox1��50      $��Fournisseur��62   $
��Left=�6G   $	��117��6b   $��	481,8,0,0q�6o   $	��Top=�6�   $	��138��6�   .��51      �� -   5        $ textBox��51   "   $
��Left=�63   $��23��6N   $��	13,33,0,0q�6Z   $
 Wrap=�6m   $��#####��6�   $	��Top=�6�   $��78��6�   52      �� 53      -   5        $ label4��53      $��Référence��6,   $
��Left=�6@   $��
496,35,0,0q�6[   $	��Top=�6o   �� 54      -   5        $ btn_voir��54      $��Voir la fiche��6/   $
��Left=�6G   $��
512,94,0,0q�6b   $	��Top=�6v   $��75��6�   6�   �� 55      -    5        $ lblqtestock��55      $��Quantité en stock��61   $
��Left=�6M   $��
223,31,0,0q�6h   $	��Top=�6|   %  Xceed.Wpf.Toolkit.IntegerUpDown  56      �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$	 235X�6)   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	Increment$ 1X�65      Maximum$
 5000X�6C      Minimum$ 50X�6R   $��336,30,196,210q�6_   �� 57      -!   5        $ 
lblqtecomm��57      $��Quantité commandée��60   $
��Left=�6M   $��
201,70,0,0q�6h   $	��Top=�6|     58      $ 68X�6)   $ 1X�64   $
 5000X�6B   $ 50X�6Q   $��336,71,196,169q�6^   �� 59      -"   5        $ 	groupBox4��59      $
��Prix��62   $
��Left=�6@   $��	16,20,0,0q�6[   $	��Top=�6n   $��63��6�   $	��133��6�   .��5:           FormatString$ C0��6-   $
 1564X�6?   $ 1X�6L   $
 5000X�6Z   $ 50X�6i   $��0,19,0,0q�6v   5;      5=      5>      5?      �� 5@   
   -#   5        $ TRAVEL_BASS_JPG��5@      $��573,40,86,354q�6)   $��Z-produit.jpg��6@   $
��Fill=�6W   �� 5A   
   -$   5        $ 
btn_editer��5A      $��Editer��6%   $
��Left=�66   $��224,410,0,0q�6Q   $	��Top=�6f   $��75��6~   5B      5C      