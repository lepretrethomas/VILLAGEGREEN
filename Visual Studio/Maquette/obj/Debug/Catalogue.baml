   M S B A M L   `   `   `  ����C  ?Maquette, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:MaquetteMaquette  5   	       Maquette.Catalogue   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   (localclr-namespace:Maquette     5   	     � Title$  	Catalogue��5   	   $	��480��6   $	��720��6(   .��5	      � .+�5
   
   �� -   5         ��Name$ VG_logo_mini_jpg��5
      $��0,0,673,391q�6*   $��Z-VG_logo_mini.jpg��6?   $
��Fill=�6[   �� 5   
   -   5         ��Name$ btn_quitter��5      $��Quitter��6&   $
��Left=�68   $��
37,410,0,0q�6S   $	��Top=�6g   $��75��6   6�   �� 5   
   -   5        $ btn_revenir��5      $��Revenir��6&   $
��Left=�68   $��605,410,0,0q�6S   $	��Top=�6h   $��75��6�   6�   �� 5   
   -   5         ��Name$ label1��5      $��	Catalogue��6    $
��Left=�64   $��	71,-6,0,0q�6O   $	��Top=�6b   $��32(�6z   �� 5   
   -   5         ��Name$ comboBox��5      $
��Left=�6%   $��
144,50,0,0q�6@   $	��Top=�6T   $	��150��6l   $��13.333(�6x   �� 5   
   -   5        $ 	comboBox1��5      $
��Left=�6&   $��
461,50,0,0q�6A   $	��Top=�6U   $	��200��6m   $��13.333(�6y   �� 5   
   -   5        $ label2��5      $��Rubrique��6    $
��Left=�63   $��	52,45,0,0q�6N   $	��Top=�6a   $��13.333(�6y   �� 5   
   -   5        $ label3��5      $��Sous-rubrique��6    $
��Left=�68   $��
336,46,0,0q�6S   $	��Top=�6g   $��13.333(�6   &   System.Windows.Controls.DataGrid  5   
   -	   5          Name$ DataGridPoint��5   s   $
��Left=�6   $	��239��6.   $��
41,135,0,0q�6;   $	��Top=�6O   $	��630��6g      AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$  Reférence ��6%   	   
IsReadOnly	 . 1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6:   �� *Référence+6X     5      $J D                            Désignation                            ��6%   	 . 
 6r   �� *Nom+6�     5      $: 4                      Libellé                      ��6%   	 . 
 6b   �� *
CodePostal+6�     5      $      Prix     ��6%   	 . 
 6=   �� *
CodePostal+6\     5      $ Aperçu��6%   	 . 
 65   �� *
CodePostal+6T   5      �� 5   
   -
   5         ��Name$ 	scrollBar��5      $
��Left=�6'   $	��216��6B   $��
24,157,0,0q�6O   $	��Top=�6c   $��14��6{   �� 5   
   -   5         ��Name$ groupBox��5      $��Filtre��6%   $
��Left=�65   $��	43,71,0,0q�6P   $	��Top=�6c   $	��627��6{   $��52��6�   .��5      �� -   5         ��Name$ slider��5      $
��Left=�6%   $	��100��6@   $��213,-32,0,-38q�6M   $	��Top=�6d    J� RenderTransformOrigin$ 0.5,0.5&�6|   ���	#FF919191z�5      V� 5       .~�5!      �� �� 5"      �� 5#       �� Angle$ -90.000Q�6*   T� 5$      5%      5'      5(      �� 5)   
   -   5        $ label��5)      $
��Prix��6   $
��Left=�6.   $��
179,90,0,0q�6I   $	��Top=�6]   �� 5*   
   -   5        $ 	comboBox2��5*      $
��Left=�6&   $��
417,93,0,0q�6A   $	��Top=�6U   $	��120��6m   �� 5+   
   -   5        $ label4��5+      $��Fournisseur��6    $
��Left=�66   $��
336,90,0,0q�6Q   $	��Top=�6e   �� 5,   
   -   5         ��Name$ textBox1��5,      $
��Left=�6$   $��23��6?   $��	512,8,0,0q�6K    �� TextWrapping$
 Wrap=�6^   $�� ��6r   $	��Top=�6z   $	��160��6�   �� 5-   
   -   5        $ button2��5-      $
��Left=�6"   $��	680,8,0,0q�6=   $	��Top=�6P   $��20��6h   $��23��6s   .��5.      �� -   5        $ recherche2_jpg��5.      $��Z-recherche.jpg��6,   $
��Fill=�6E   $��19��6T   $��16��6`   5/      51      52      