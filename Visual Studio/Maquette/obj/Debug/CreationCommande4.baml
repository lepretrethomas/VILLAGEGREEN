   M S B A M L   `   `   `  ����C  ?Maquette, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MaquetteMaquette  5   	        Maquette.CreationCommande4   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=2.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   Y UXceed.Wpf.DataGrid, Version=2.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f45xcdg*http://schemas.xceed.com/wpf/xaml/datagrid  5   	   "localclr-namespace:Maquette  5   	     � Title$  CreationCommande4��5
   	   $	��480��6#   $	��720��60   .��5      � .+�5   
   �� -   5         ��Name$ VG_logo_mini_jpg��5      $��0,0,673,391q�6*   $��Z-VG_logo_mini.jpg��6?   $
��Fill=�6[   �� 5   
   -   5         ��Name$ label1��5      $��Création de commande��6    $
��Left=�6?   $��	72,47,0,0q�6Z   $	��Top=�6m   $��32(�6�   �� 5   
   -   5         ��Name$ btn_quitter��5      $��Quitter��6&   $
��Left=�68   $��
37,410,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ label2��5      $��Référence du produit :��6    $
��Left=�6A   $��
81,326,0,0q�6\   $	��Top=�6p   �� 5   
   -   5        $ btn_terminer��5      $��Terminer��6'   $
��Left=�6:   $��505,410,0,0q�6U   $	��Top=�6j   $��75��6�   6�   �� 5   
   -   5        $ btn_annuler��5      $��Annuler��6&   $
��Left=�68   $��605,410,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5         ��Name$ textBox��5      $
��Left=�6#   $��20��6>   $��214,329,0,0q�6J    �� TextWrapping$
 Wrap=�6_   $�� ��6s   $	��Top=�6{   $��70��6�   �� 5   
   -   5        $ label��5      $��Quantité :��6   $
��Left=�64   $��146,348,0,0q�6O   $	��Top=�6d   %  Xceed.Wpf.Toolkit.IntegerUpDown  5   
   �  �Xceed.Wpf.Toolkit.Primitives.UpDownBase`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   Value$ 0X�6   �  �Xceed.Wpf.Toolkit.NumericUpDown`1[[System.Nullable`1[[System.Int32, mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]], mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089]]   	Increment$ 1X�6'      Maximum$
 5000X�65   	   Minimum$	 50X�6D   $��214,352,0,0q�6Q   $
��Left=�6f   $	��Top=�6�   $��70��6�   &   System.Windows.Controls.DataGrid  5   
   -	   5        $��DataGridPoint��5   s   $
��Left=�6   $	��119��6.   $��
81,181,0,0q�6;   $	��Top=�6O   $	��559��6g   
   AutoGenerateColumns
 .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Reférence ��6%      
IsReadOnly . 1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   �� *Référence+6X     5      $  Type ��6%    .  65   �� *	Adresse+6Q     5      $N H                              Désignation                              ��6%    .  6v   �� *Nom+6�     5      $  Quantité ��6%    .  69   �� *
CodePostal+6X     5      $      Prix     ��6%    .  6=   �� *
CodePostal+6\   5      �� 5   
   -
   5        $ label4��5      $��Bon de commande��6    $
��Left=�6:   $��	33,92,0,0q�6U   $	��Top=�6h   $��21.333(�6�   �� 5    
   -   5         ��Name$ 	scrollBar��5       $
��Left=�6'   $	��113��6B   $��
64,206,0,0q�6O   $	��Top=�6c   $��14��6{   �� 5!   
   -   5        $ button��5!      $
��Left=�6!   $��321,331,0,0q�6<   $	��Top=�6Q   $��35��6i   $��35��6t   .��5"      �� -   5        $ ajouter_jpg��5"      $��33��6)   $��Z-ajouter.jpg��65   $
��Fill=�6L   $��31��6[   5#      �� 5$   
   -   5        $ button1��5$      $
��Left=�6"   $��366,331,0,0q�6=   $	��Top=�6R   $��35��6j   $��35��6u   .��5%      �� -   5        $ retirer_jpg��5%      $��33��6)   $��Z-retirer.jpg��65   $
��Fill=�6L   $��31��6[   5&      �� 5'   
   -   5         ��Name$ groupBox��5'      $��Client��6%   $
��Left=�65   $	��105��6P   $��
500,66,0,0q�6]   $	��Top=�6q   $	��180��6�   .��5(      �� -   5        $ label8��5(      $��Référence��6$   $
��Left=�68   $��11,6,0,0q�6S   $	��Top=�6e   5)      �� 5*   
   -   5        $ label7��5*      $	��Nom��6    $
��Left=�6.   $��543,110,0,0q�6I   $	��Top=�6^   �� 5+   
   -   5        $ label9��5+      $��Prénom��6    $
��Left=�61   $��528,131,0,0q�6L   $	��Top=�6a   �� 5,   
   -   5        $ textBox4��5,      $
��Left=�6$   $��20��6?   $��
579,91,0,0q�6K   $
 Wrap=�6_   $��#####��6s   $	��Top=�6�   $��78��6�   �� 5-   
   -   5        $ textBox5��5-      $
��Left=�6$   $��20��6?   $��579,135,0,0q�6K   $
 Wrap=�6`   $��DEVLOG��6t   $	��Top=�6�   $��78��6�   �� 5.   
   -   5        $ textBox6��5.      $
��Left=�6$   $��20��6?   $��579,113,0,0q�6K   $
 Wrap=�6`   $
��AFPA��6t   $	��Top=�6�   $��78��6�   (  "System.Windows.Controls.DatePicker  5/   
   $
��Left=�6   $��
40,131,0,0q�60   $	��Top=�6D   �� 50   
   -   5        $ button2��50      $
��Left=�6"   $��410,331,0,0q�6=   $	��Top=�6R   $��35��6j   $��35��6u   .��51      �� -   5        $ supprimer_jpg��51      $��33��6+   $��Z-supprimer.jpg��67   $
��Fill=�6P   $��31��6_   52      �� 53   
   -   5        $ label3��53      $��Total :��6    $
��Left=�62   $��535,302,0,0q�6M   $	��Top=�6b   �� 54   
   -   5        $ label5��54      $��Réduction :��6    $
��Left=�66   $��507,349,0,0q�6Q   $	��Top=�6f   �� 55   
   -   5        $ label6��55      $��	A payer :��6    $
��Left=�64   $��520,373,0,0q�6O   $	��Top=�6d   �� 56   
   -   5        $ textBox1��56      $
��Left=�6$   $��20��6?   $��577,305,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��60��6�   �� 57   
   -   5        $ textBox2��57      $
��Left=�6$   $��20��6?   $��577,353,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��60��6�   �� 58   
   -   5        $ textBox3��58      $
��Left=�6$   $��20��6?   $��577,377,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��60��6�   �� 59   
   -   5        $ label5_Copy��59      $��Coefficient :��6%   $
��Left=�6=   $��503,325,0,0q�6X   $	��Top=�6m   �� 5:   
   -    5        $ textBox9��5:      $
��Left=�6$   $��20��6?   $��577,329,0,0q�6K   $
 Wrap=�6`   $�� ��6t   $	��Top=�6|   $��60��6�   5;      5<      