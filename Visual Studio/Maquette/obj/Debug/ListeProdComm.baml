   M S B A M L   `   `   `  ����C  ?Maquette, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MaquetteMaquette  5   	       Maquette.ListeProdComm   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Maquette     5   	     � Title$  ListeProdComm��5   	   $	��480��6   $	��720��6,   .��5	      � .+�5
   
   �� -   5         ��Name$ VG_logo_mini_jpg��5
      $��0,0,673,391q�6*   $��Z-VG_logo_mini.jpg��6?   $
��Fill=�6[   �� 5   
   -   5         ��Name$ label1��5      $#��Liste des produits commandés��6    $
��Left=�6G   $��	72,47,0,0q�6b   $	��Top=�6u   $��32(�6�   �� 5   
   -   5         ��Name$ btn_quitter��5      $��Quitter��6&   $
��Left=�68   $��
37,410,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ btn_revenir��5      $��Revenir��6&   $
��Left=�68   $��605,410,0,0q�6S   $	��Top=�6h   $��75��6�   6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��DataGridPoint��5   s   $
��Left=�6   $	��270��6.   $��
53,119,0,0q�6;   $	��Top=�6O   $	��617��6g      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Référence ��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Référence+6X     5      $z t                                                    Désignation                                                    ��6%    .  6�   �� *Nom+6�     5      $  Quantité commandée ��6%    .  6C   �� *
CodePostal+6b   5      �� 5   
   -   5        	 ��Name$	 	scrollBar��5      $
��Left=�6'   $	��241��6B   $��
36,147,0,0q�6O   $	��Top=�6c   $��14��6{   5      5      