   M S B A M L   `   `   `  ����C  ?Maquette, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MaquetteMaquette  5   	        Maquette.RechercheCommande   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Maquette     5   	     � Title$  RechercheCommande��5   	   $	��480��6#   $	��720��60   .��5	      � .+�5
   
   �� -   5         ��Name$ VG_logo_mini_jpg��5
      $��0,0,673,391q�6*   $��Z-VG_logo_mini.jpg��6?   $
��Fill=�6[   �� 5   
   -   5         ��Name$ label1��5      $��Recherche d'une commande��6    $
��Left=�6C   $��	72,47,0,0q�6^   $	��Top=�6q   $��32(�6�   �� 5   
   -   5         ��Name$ btn_quitter��5      $��Quitter��6&   $
��Left=�68   $��
37,410,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ label2��5      $��Par son numéro :��6    $
��Left=�6;   $��
147,96,0,0q�6V   $	��Top=�6j   �� 5   
   -   5        $ btn_suivant��5      $��Suivant��6&   $
��Left=�68   $��505,410,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5        $ btn_annuler��5      $��Annuler��6&   $
��Left=�68   $��605,410,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��23��6>   $��260,132,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��156��6�   �� 5   
   -   5        $ label��5      $��Par le nom du client :��6   $
��Left=�6@   $��125,130,0,0q�6[   $	��Top=�6p   �� 5   
   -	   5        $ textBox1��5      $
��Left=�6$   $��23��6?   $��260,165,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��156��6�   �� 5   
   -
   5        $ label3��5      $��Résultat de la recherche��6    $
��Left=�6C   $��
81,226,0,0q�6^   $	��Top=�6r   �� 5   
   -   5        $ btn_visualiser��5      $��
Visualiser��6)   $
��Left=�6>   $��556,227,0,0q�6Y   $	��Top=�6n   $��75��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��DataGridPoint��5   s   $
��Left=�6   $	��101��6.   $��
80,251,0,0q�6;   $	��Top=�6O   $	��552��6g      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ N° de commande��6%   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6=   �� *Référence+6[     5      $       Date      ��6%   	 . 
 6?   �� *Nom+6W     5      $             Etat           ��6%   	 . 
 6I   �� *
Catégorie+6g     5      $  Réf Client ��6%   	 . 
 6;   �� *	Adresse+6W     5      $            Nom           ��6%   	 . 
 6H   �� *	Adresse+6d     5      $        Prénom       ��6%   	 . 
 6C   �� *	Adresse+6_   5      �� 5   
   -   5        $ label4��5      $$��Par la référence du client :��6    $
��Left=�6G   $��100,163,0,0q�6b   $	��Top=�6w   �� 5    
   -   5        $ textBox2��5       $
��Left=�6$   $��23��6?   $��
260,99,0,0q�6K   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��156��6�   �� 5!   
   -   5        $ button��5!      $
��Left=�6!   $��
423,99,0,0q�6<   $	��Top=�6P   $��20��6h   $��23��6s   .��5"      �� -   5        $ recherche_jpg��5"      $��Z-recherche.jpg��6+   $
��Fill=�6D   $��19��6S   $��16��6_   5#      �� 5$   
   -   5        $ button2��5$      $
��Left=�6"   $��423,132,0,0q�6=   $	��Top=�6R   $��20��6j   $��23��6u   .��5%      �� -   5        $ recherche2_jpg��5%      $��Z-recherche.jpg��6,   $
��Fill=�6E   $��19��6T   $��16��6`   5&      �� 5'   
   -   5        $ button3��5'      $
��Left=�6"   $��423,165,0,0q�6=   $	��Top=�6R   $��20��6j   $��23��6u   .��5(      �� -   5        $ recherche3_jpg��5(      $��Z-recherche.jpg��6,   $
��Fill=�6E   $��19��6T   $��16��6`   5)      �� 5*   
   -   5        $ label5��5*      $��Par son état :��6    $
��Left=�69   $��168,199,0,0q�6T   $	��Top=�6i   �� 5+   
   -   5        $ button3_Copy��5+      $
��Left=�6'   $��423,200,0,0q�6B   $	��Top=�6W   $��20��6o   $��23��6z   .��5,      �� -   5        $ recherche3_jpg1��5,      $��Z-recherche.jpg��6-   $
��Fill=�6F   $��19��6U   $��16��6a   5-      �� 5.   
   -   5         ��Name$ comboBox��5.      $
��Left=�6%   $��260,200,0,0q�6@   $	��Top=�6U   $	��156��6m   $��23��6y   5/      50      