   M S B A M L   `   `   `  ����J  FBENYEMNA_BURY_B, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BENYEMNA_BURY_BBENYEMNA_BURY_B  5   	   *    $BENYEMNA_BURY_B.AfficherLesCommandes   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:BENYEMNA_BURY_B     5   	     � Title$  AfficherLesCommandes��5   	   $	��450��6&   $	��800��63   .��5	      � .+�5
   
   �� -   5         ��Name$ infoCommande��5
       �� Left$	 375��6)   
 �� Top$ 54��6;   $��0,10,-0.4,54q�6�   ��6K   �� *this.pizzeria.Commandes+ �� Mode$ OneWay=� �� View 5      �� 5      .P�5      �� $��Numéro��6%    �� Width$	 125��65    �� DisplayMemberBinding 6A   �� *NumCommande+$ OneWay=��� 5      $
��Date��6%   $	 125��63    6?   �� *DateCommande+$ OneWay=��� 5      $��Client��6%   $	 100��65    6A   �� *	NomClient+$ OneWay=��� 5      $��Commis��6%   $	 100��65    6A   �� *	NomCommis+$ OneWay=��� 5      $��Livreur��6%   $	 100��66    6B   �� *
NomLivreur+$ OneWay=��� 5      $
��Etat��6%   $	 100��63    6?   �� *Etat+$ OneWay=��� 5      $��Solde��6%   $ 75��64    6?   �� *Solde+$ OneWay=��� 5      $
��Prix��6%   $ 75��63    6>   �� *Prix+$ OneWay=�5      5      �� 5   
   -   5        $��Retour��5      $
��Left=�6"   $��
10,391,0,0q�6=   $	��Top=�6Q   $��75��6i   6t   5      5      