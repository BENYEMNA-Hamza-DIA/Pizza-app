   M S B A M L   `   `   `  ����J  FBENYEMNA_BURY_B, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:BENYEMNA_BURY_BBENYEMNA_BURY_B  5   	   '    !BENYEMNA_BURY_B.AffichageCommande   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:BENYEMNA_BURY_B     5   	     � Title$  AffichageCommande��5   	   $	��450��6#   $	��800��60    � 	Resources 5	       S� 
ObjectType   BENYEMNA_BURY_B.Pizza S� 
MethodName   toString��%C   &	        S� 5
   
   "  6   $ ToString��5      5      5      .��5      � .+�5   
   �� -   5         ��Name$ pizzas��5       �� Left$	 375��6#   
 �� Top$ 54��65   $��0,10,-0.4,255q�6�   ��6E   �� *this.commande.ListePizzas+ �� Mode$ OneWay=� 5        
calculPrix  	prixPizza �� Source��%�   &	       &	 +     7  S� 5      $ PrixToString��6%   6?   �� 5      .R�5      �� $	��300��6    ��6,   �� 8   $ OneWay=�5      5      	 �� View	 5      �� 5      .P�5      �� $��Pizza(s)��6%   
 �� Width$	
 500��67   �� 5      $
��Prix��6%   $	
 300��63    �� DisplayMemberBinding 6?   �� *Prix+$ OneWay=�5      5      �� 5   
   -   5        $ boissons��5      $	 375��6%   $ 54��67   $��0,166,-0.4,99q�6�   ��6G   �� *this.commande.ListeBoissons+$ OneWay=�	 5      �� 5      .P�5       �� $��
Boisson(s)��6%   $	
 500��69   �� 5!      $
��Prix��6%   $	
 300��63    6?   �� *Prix+$ OneWay=�5"      5$      �� 5%   
   -   5        $��Retour��5%      $
��Left=�6"   $��
10,391,0,0q�6=   $	��Top=�6Q   $��75��6i   6t   �� 5&   
   -   5        $��Suivant��5&      $
��Left=�6#   $��709,391,0,0q�6>   $	��Top=�6S   $��75��6k   6v   �� 5'   
   -   5         ��Name$ 	prixTotal��5'      $
��Left=�6'   $��530,350,0,0q�6B   $
��Wrap=�6W   $�� ��6k   $	��Top=�6s   $��75��6�   $��20��6�   �� 5(   
   -   5        $ Total��5(      $
��Left=�6#   $��450,350,0,0q�6>   $
��Wrap=�6S   $��Prix Total:��6g    �� TextAlignment$ Center=�6z   $	��Top=�6�   $��75��6�   $��20��6�   5*      5+      