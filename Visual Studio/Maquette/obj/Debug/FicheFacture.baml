   M S B A M L   `   `   `  ����C  ?Maquette, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MaquetteMaquette  5   	       Maquette.FicheFacture   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Maquette     5   	     � Title$  FicheFacture��5   	   $	��480��6   $	��720��6+   .��5	      � .+�5
   
   �� -   5         ��Name$ VG_logo_mini_jpg��5
      $��0,0,673,391q�6*   $��Z-VG_logo_mini.jpg��6?   $
��Fill=�6[   �� 5   
   -   5         ��Name$ label1��5      $��Facture n° #####��6    $
��Left=�6;   $��	72,47,0,0q�6V   $	��Top=�6i   $��32(�6�   �� 5   
   -   5         ��Name$ btn_quitter��5      $��Quitter��6&   $
��Left=�68   $��
37,410,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ btn_commande��5      $
��Voir��6'   $
��Left=�66   $��385,283,0,0q�6Q   $	��Top=�6f   $��35��6~   6�   �� 5   
   -   5        $ btn_menu��5      $��Retour au menu��6#   $
��Left=�6<   $��580,410,0,0q�6W   $	��Top=�6l   $	��100��6�   6�   �� 5   
   -   5        $ label4��5      $��émis le 20 Janvier 2016��6    $
��Left=�6B   $��	75,94,0,0q�6]   $	��Top=�6p   $��21.333(�6�   �� 5   
   -   5        $ label6��5      $��	A payer :��6    $
��Left=�64   $��521,304,0,0q�6O   $	��Top=�6d   �� 5   
   -   5         ��Name$ textBox3��5      $
��Left=�6$   $��20��6?   $��584,308,0,0q�6K    �� TextWrapping$
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��60��6�   �� 5   
   -	   5         ��Name$ groupBox��5      $��Client��6%   $
��Left=�65   $	��128��6P   $��
520,12,0,0q�6]   $	��Top=�6q   $	��180��6�   .��5      �� -
   5        $ label8��5      $��Référence��6$   $
��Left=�68   $��11,6,0,0q�6S   $	��Top=�6e   5      �� 5   
   -   5        $ label7��5      $	��Nom��6    $
��Left=�6.   $��
563,56,0,0q�6I   $	��Top=�6]   �� 5   
   -   5        $ label9��5      $��Prénom��6    $
��Left=�61   $��
548,77,0,0q�6L   $	��Top=�6`   �� 5   
   -   5        $ textBox4��5      $
��Left=�6$   $��20��6?   $��
599,37,0,0q�6K   $
 Wrap=�6_   $��#####��6s   $	��Top=�6�   $��78��6�   �� 5   
   -   5        $ textBox5��5      $
��Left=�6$   $��20��6?   $��
599,81,0,0q�6K   $
 Wrap=�6_   $��DEVLOG��6s   $	��Top=�6�   $��78��6�   �� 5   
   -   5        $ textBox6��5      $
��Left=�6$   $��20��6?   $��
599,59,0,0q�6K   $
 Wrap=�6_   $
��AFPA��6s   $	��Top=�6   $��78��6�   �� 5   
   -   5        $ btn_voir��5      $
��Voir��6#   $
��Left=�62   $��590,110,0,0q�6M   $	��Top=�6b   $��40��6z   6�   �� 5   
   -   5        $ label��5      $��Statut de la commande :��6   $
��Left=�6A   $��104,312,0,0q�6\   $	��Top=�6q   �� 5   
   -   5        $ textBox��5      $
��Left=�6#   $��20��6>   $��256,315,0,0q�6J   $
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $	��120��6�   �� 5   
   -   5        $ btn_supprimer��5      $��	Supprimer��6(   $
��Left=�6<   $��400,410,0,0q�6W   $	��Top=�6l   $��75��6�   6�   �� 5   
   -   5        $ btn_modifier��5      $��Modifier��6'   $
��Left=�6:   $��490,410,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5        $ label10��5      $��Etat de la facture :��6!   $
��Left=�6@   $��137,341,0,0q�6[   $	��Top=�6p   �� 5    
   -   5        $ textBox8��5       $
��Left=�6$   $��20��6?   $��255,345,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $	��120��6�   �� 5!   
   -   5        $ label2_Copy��5!      $	��Nom��6%   $��Right=�63   $��0,165,559,0q�6O   $	��Top=�6d   �� 5"   
   -   5        $ label3_Copy��5"      $��Prénom��6%   $��Right=�66   $��0,166,260,0q�6R   $	��Top=�6g   �� 5#   
   -   5        $ label4_Copy��5#      $	��Rue��6%   $��Right=�63   $��0,194,557,0q�6O   $	��Top=�6d   �� 5$   
   -   5        $ label5_Copy��5$      $��Code Postal��6%   $��Right=�6;   $��0,223,557,0q�6W   $	��Top=�6l   �� 5%   
   -   5        $ textBox_Copy��5%      $
��Left=�6(   $��24��6C   $��165,168,0,0q�6O   $
 Wrap=�6d   $��DEVLOG��6x   $	��Top=�6�   $	��220��6�   �� 5&   
   -   5        $ textBox1_Copy��5&      $
��Left=�6)   $��23��6D   $��463,170,0,0q�6P   $
 Wrap=�6e   $
��AFPA��6y   $	��Top=�6�   $	��182��6�   �� 5'   
   -   5        $ textBox2_Copy��5'      $
��Left=�6)   $��23��6D   $��165,198,0,0q�6P   $
 Wrap=�6e   $��30 rue de Poulainville��6y   $	��Top=�6�   $	��480��6�   �� 5(   
   -   5        $ textBox3_Copy��5(      $
��Left=�6)   $��23��6D   $��165,227,0,0q�6P   $
 Wrap=�6e   $��80000��6y   $	��Top=�6�   $��80��6�   �� 5)   
   -   5        $ textBox4_Copy��5)      $
��Left=�6)   $��23��6D   $��311,228,0,0q�6P   $
 Wrap=�6e   $��AMIENS��6y   $	��Top=�6�   $	��334��6�   �� 5*   
   -    5        $ label2��5*      $��Adresse de facturation��6    $
��Left=�6A   $��
75,141,0,0q�6\   $	��Top=�6p   �� 5+   
   -!   5        $ label11��5+      $��Ville��6!   $
��Left=�61   $��265,223,0,0q�6L   $	��Top=�6a   �� 5,   
   -"   5        $ label3��5,      $��Commande n°��6    $
��Left=�66   $��165,279,0,0q�6Q   $	��Top=�6f   �� 5-   
   -#   5        $ textBox1��5-      $
��Left=�6$   $��20��6?   $��257,283,0,0q�6K   $
 Wrap=�6`   $��#####��6t   $	��Top=�6�   $	��120��6�   �� 5.   
   -$   5        $ 
btn_editer��5.      $��Editer��6%   $
��Left=�66   $��224,410,0,0q�6Q   $	��Top=�6f   $��75��6~   �� 5/   
   -%   5        $ button��5/      $��
Règlement��6!   $
��Left=�65   $��569,338,0,0q�6P   $	��Top=�6e   $��75��6}   6�   50      51      