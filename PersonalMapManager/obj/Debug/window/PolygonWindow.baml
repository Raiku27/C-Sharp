   M S B A M L   `   `   `  ����M  IPersonalMapManager, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:PersonalMapManager.windowPersonalMapManager.window  5   	   -    'PersonalMapManager.window.PolygonWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   9local'clr-namespace:PersonalMapManager.window     5   	   -   5          � Title$  PolygonWindow��5   	   $	��500��5	      $	��350��5
       � 
ResizeMode$ NoResize=�5       � WindowStartupLocation$ CenterScreen=�5      .��5      � .+�5      �� ��5      �� 5      .��5      �  � Color$ #0935e6��6    � Offset$	 0.0Q�6$   � 5      $ #5c6bab��6   $ 1Q�6$   5      5      �� 5      $��Polygon:��6
   $��20,20,20,401q�6   $
��Left=�63   $��Center=�6U   $��24(�6w   $��Unispace)�6�   $��0q�6�   �� 5      $��Description:��6
   $��20,80,176,351q�6!   $
��Left=�68   $��Center=�6Z   $��20(�6|   $��Unispace)�6�   $��0q�6�   �� 5      $��Remplissage��6
   $��20,120,176,311q�6    $
��Left=�68   $��Center=�6Z   $��20(�6|   $��Unispace)�6�   $��0q�6�   �� 5      $��Contour��6
   $��20,160,176,271q�6   $
��Left=�64   $��Center=�6V   $��20(�6x   $��Unispace)�6�   $��0q�6�   �� 5      $��Opacité��6
   $��20,200,176,231q�6   $
��Left=�64   $��Center=�6V   $��20(�6x   $��Unispace)�6�   $��0q�6�   �� 5      $��Coordonnee:��6
   $��20,240,161,191q�6    $
��Left=�68   $��Center=�6Z   $��22(�6|   $��Unispace)�6�   $��0q�6�   �� 5      $��	Latitude:��6
   $��30,278,206,163q�6   $
��Left=�66   $��Center=�6X   $��18(�6z   $��Unispace)�6�   $��0q�6�   �� 5       $��	Latitude:��6
   $��30,308,206,133q�6   $
��Left=�66   $��Center=�6X   $��18(�6z   $��Unispace)�6�   $��0q�6�   �� 5"      -   5         ��Name$ TextBoxDescription��5"      $��173,80,20,351q�6E   $��30��6\   $��Unispace)�6h   $��16(�6~   $��Center=�6�   ��6(   �� *Description+6�   �� 5#      -   5         ��Name$ ComboBoxRemplissage��5#      $��30��6O   $��173,120,20,311q�6[   $��Unispace)�6s   $��16(�6�   $��Center=�6�    �� SelectedItem 6*   �� *Remplissage+6�   �� 5$      -   5        $ ComboBoxContour��5$      $��30��6G   $��173,160,20,271q�6S   $��Unispace)�6k   $��16(�6�   $��Center=�6�    6&   �� *	Contour+6�   �� 5%      -   5        $ TextBoxOpacité��5%      $��30��6C   $��253,200,20,231q�6O   $��Center=�6g   $��Center=�6�   $��Unispace)�6�   $��16(�6�   ��6$   �� *StringOpacite+6�   �� 5&      -   5         ��Name$ SliderOpacité��5&      	 � Minimum$	 0Q�6<   
 � Maximum$
 1Q�6H   $��173,205,96,236q�6T   $��Center=�6l    � Value 6"   �� *	Opacite+6l   �� 5'      -   5        $ TextBoxLatitude��5'      $��138,50,132,163q�6?   $��Unispace)�6W   $��14(�6m   $��Center=�6{   $��Center=�6�   $��Bottom=�6�   $��25��6�   ��6%   �� *
Latitude+6�   �� 5(      -   5        $ TextBoxLongitude��5(      $��138,50,132,130q�6A   $��Unispace)�6Y   $��14(�6o   $��Center=�6}   $��Center=�6�   $��Bottom=�6�   $��25��6�   ��6&   �� *	Longitude+6�   �� 5*      -	   5         ��Name$ ButtonAjouter��5*      $��Ajouter��6>   $��222,0,10,163q�6P   $��Center=�6f   $��Center=�6�   $��Unispace)�6�   $��14(�6�   
��� � �
���   �$��25��6�   $��Bottom=�6  �� 5+      -
   5        $ ButtonRetirer��5+      $��Retirer��6>   $��222,0,10,130q�6P   $��Center=�6f   $��Center=�6�   $��Unispace)�6�   $��14(�6�   
���  ��
���   �$��25��6�   $��Bottom=�6   �� 5-      -   5         ��Name$ ListBoxCoordonnees��5-      $��20,338,20,60q�6(   �� 5/      -   5        $ ButtonAnnuler��5/      $��Annuler��6>   $��
20,0,20,20q�6P   $��70��6d   $��30��6o   $��Bottom=�6{   $
��Left=�6�   
���  ��
���   �$��2q�6�   $��14(�6�   $��Unispace)�6�   $��Center=�6  $��Center=�62  �� 50      -   5        $ ButtonAppliquer��50      $��	Appliquer��6B   $��
20,0,20,20q�6V   $��90��6j   $��30��6u   $��Bottom=�6�   $��Center=�6�   
��� � �
���   �$��2q�6�   $��14(�6�   $��Unispace)�6  $��Center=�6  $��Center=�6<  �� 51      -   5        $ ButtunOk��51      $��Ok��64   $��
20,0,20,20q�6A   $��70��6U   $��30��6`   $��Bottom=�6l   $��Right=�6�   
������ 
���   �$��2q�6�   $��14(�6�   $��Unispace)�6�   $��Center=�6  $��Center=�6,  56      57      