   M S B A M L   `   `   `  ����C  ?Maquette, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MaquetteMaquette  5   	       Maquette.ListeFourProd   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Maquette     5   	     � Title$  ListeFourProd��5   	   $	��480��6   $	��720��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ VG_logo_mini_jpg��5
      $��0,0,673,391q�6*   $��Z-VG_logo_mini.jpg��6?   $
��Fill=�6[   �� 5   
   -   5         ��Name$ label1��5      $��Liste des produits��6    $
��Left=�6=   $��	72,47,0,0q�6X   $	��Top=�6k   $��32(�6�   �� 5   
   -   5         ��Name$ btn_quitter��5      $��Quitter��6&   $
��Left=�68   $��
37,410,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ btn_revenir��5      $��Revenir��6&   $
��Left=�68   $��605,410,0,0q�6S   $	��Top=�6h   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��DataGridPoint��5   s   $
��Left=�6   $	��234��6.   $��
31,120,0,0q�6;   $	��Top=�6O   $	��650��6g      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Référence ��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Référence+6X     5      $       Type      ��6%    .  6?   �� *
CodePostal+6^     5      $� |                                                        Désignation                                                        ��6%    .  6�   �� *Nom+6�     5      $     Stock    ��6%    .  6<   �� *
CodePostal+6[   5      �� 5   
   -   5        	 ��Name$	 	scrollBar��5      $
��Left=�6'   $	��209��6B   $��
14,144,0,0q�6O   $	��Top=�6c   $��14��6{   �� 5   
   -   5        
 ��Name$
 groupBox��5      $��Fournisseur��6%   $
��Left=�6:   $��97��6U   $��
520,12,0,0q�6a   $	��Top=�6u   $	��180��6�   .��5      �� -   5        $ label8��5      $��Référence��6$   $
��Left=�68   $��11,6,0,0q�6S   $	��Top=�6e   5      �� 5   
   -	   5        $ label7��5      $	��Nom��6    $
��Left=�6.   $��
563,56,0,0q�6I   $	��Top=�6]   �� 5   
   -
   5         ��Name$ textBox4��5      $
��Left=�6$   $��20��6?   $��
599,37,0,0q�6K    �� TextWrapping$
 Wrap=�6_   $��#####��6s   $	��Top=�6�   $��78��6�   �� 5   
   -   5        $ textBox6��5      $
��Left=�6$   $��20��6?   $��
599,59,0,0q�6K   $
 Wrap=�6_   $��	FOURNINIS��6s   $	��Top=�6�   $��78��6�   5      5      