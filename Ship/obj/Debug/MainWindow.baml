   M S B A M L   `   `   `  ����?  ;Ship, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ShipShip  5   	   clr-namespace:ShipShip  6*       Ship.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Ship     5   	   )
viewmodelsclr-namespace:Ship     6*   -   5          �Name$  window��5   	    � Title$ 
MainWindow��5   	   $
��1080��6   $
��1920��6*      backgroundImage#���   67    � DataContext 5	         Ship.MainViewModel  5
   
    � 	Resources 5        	imgSource �� ImageSource �� Opacity��%h   &	       &	  &     ��5   
   background.png��68   �� 5   
   # �  6-   $	 0.3Q�6W   6g   5      .��5      � -   5         �Name$
 MAIN��5       � RowDefinitions 5   
   �� 5      $	��72* �6   �� 5      $��1008* �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $��3* �6#   �� 5      $��* �6#   .+�5      �� $��1��6   $��Center=�6(   $��32(�6E   $��SemiBold"�6S   	 �� Padding$	 10q�6i   �� 5      
�������$+�%⎈ Паблик-Кораблик ⎈��6&   5      5      � 5    
   -   5        $ 
SplitInTwo��5       $��1��6    5!      �� 5"      $
��313* �6#   �� 5#      $��1025* �6#    5%      �� 5&      $��* �6    .+�5)      �� $��0��6   $	��325��6)   .+�5*      �� $��Center=�6   
����p��$��18(�6T   $
��Bold"�6b   '%Инф. о части корабля:6�   �� 5+      $	��330��6   $��4q�6&   
����p��._�5,      �� -   5        
 ��Name$
 ShipPartStatus��5,   2   
���������6J   �� *CurrentCrewers+��5-      �� 5.      .R�5/   "   ��  �� Orientation$ 
Horizontal=�6-   .+�50   &   �� $��0 0 5 0q�6K   ��60   ��  �� Path$
 Name�6K   �� 51   &   $��0 0 5 0q�6O   ��60   �� $ Busyness�6O   52   #   53      55      56      �� 57      $��Center=�6   
����p��$��18(�6T   $
��Bold"�6b   Инф. о моряке:6�   �� 58      $	��100��6   $��4q�6&   
����p��
�������._�59      �� $ 
Horizontal=�6!   .+�5:      �  5;      �� 5<   "   �� 5=   "   �� 5>   "   �� 5?   "   �� 5@   "   .+�5B      �� $��0��6(   Имя6:   �� 5C      $��1��6(   Пол6:   �� 5D      $��2��6(   Занятость6@   �� 5E      $��3��6(   Сытость6>   �� 5F      $��4��6(   Местоположение6E   5G      �� 5H      -   5        $
 CrewerStatus��5H   6   
���������6L   �� *StatusedCrewer+��5I      �� 5J   "   .R�5K   &   �� $ Vertical=�61   .+�5L   *   �� $��0��64   $��0 -5 5 0q�6_   ��6D   �� $
 Name�6_   �� 5M   *   $��1��64   $��0 2 5 0q�6^   ��6D   �� $	 Sex�6^   �� 5N   *   $��2��64   $��0 2 5 0q�6c   ��6D   �� $ Busyness�6c   �� 5O   *   $��3��64   $��0 2 5 0q�6e   ��6D   �� $ 
Hungriness�6e   �� 5P   *   $��4��64   $��0 3 5 0q�6l   ��6D   �� $ CurrentRoomString�6l   5Q   '   5R   #   5T      5U      5V      � 5W       5X      �� 5Y      �� 5Z      .+�5\      �� $��0��6!   $��0 0 5 0q�62   .+�5]      �� $��Center=�6$   
����p��$��18(�6\   $
��Bold"�6j   Склад:6�   �� 5^      $	��100��6!   $��4q�6.   
����p��
�������._�5_      �� $ 
Horizontal=�6)   $��35 0 0 0q�6B   .+�5`   "   �  5a   &   �� 5b   *   �� 5c   *   .+�5e   &   �� $��0��60   	Еда:6C   �� 5f   &   $��1��60   Боезапас:6H   5g   #   �� 5h   "   -   5        $
 StockStatus��5h   >   
���������6S   �� *StatusedStock+��5i   &   �� 5j   *   .R�5k   .   �� $ Vertical=�69   .+�5l   2   �� $��43��6<   $��0��6H   $��0 0 5 0q�6s   ��6X   �� $
 Food�6s   �� 5m   2   $��1��6<   $��0 0 5 0q�6g   ��6L   �� $
 Ammo�6g   5n   /   5o   +   5q   #   5r      5s      5t      �� 5u      $��1��6!   $��5 0 0 0q�61   .+�5v      �� $��Center=�6$   
����p��$��18(�6\   $
��Bold"�6j   Сокровищница:6�   �� 5w      $	��100��6!   $��4q�6.   
����p��
�������._�5x      �� $ 
Horizontal=�6)   $��45 0 0 0q�6B   .+�5y   "   �  5z   &   �� 5{   *   �� 5|   *   �� 5}   *   .+�5   &   �� $��0��60   Добыча:6F   �� 5�   &   $��1��60   Золото:6F   �� 5�   &   $��2��60   	Рабы:6D   5�   #   �� 5�   "   -   5        $
 ChestStatus��5�   >   
���������6S   �� *StatusedTreasureRoom+��5�   &   �� 5�   *   .R�5�   .   �� $ Vertical=�69   .+�5�   2   �� $��0��6<   $��0 -2 5 0q�6i   ��6L   �� $ Bounty�6i   �� 5�   2   $��0��6<   $��0 14 5 0q�6g   ��6L   �� $
 Gold�6g   �� 5�   2   $��1��6<   $��0 14 5 0q�6i   ��6L   �� $ Slaves�6i   5�   /   5�   +   5�   #   5�      5�      5�      5�      �� 5�      $��Center=�6   
����p��$��18(�6T   $
��Bold"�6b    Состояние судна:6�   �� 5�      $	��100��6   $��4q�6&   
����p��
�������._�5�      �� $ 
Horizontal=�6!   $��95 0 0 0q�6:   .+�5�      �  5�      �� 5�   "   �� 5�   "   �� 5�   "   .+�5�      �� $��0��6(   Команда:6?   �� 5�      $��1��6(   Пушек:6=   �� 5�      $��2��6(   Состояние:6A   5�      �� 5�      -   5        $
 WholeShipStatus��5�   6   
���������6O   �� *WholeShipStatus+��5�      �� 5�   "   .R�5�   &   �� $ Vertical=�61   .+�5�   *   �� $��20��64   $��0��6@   $��0 -5 5 0q�6o   ��6P   �� $ CrewSize�6o   �� 5�   *   $��20��64   $��0��6@   $��0 12 5 0q�6|   ��6P   �� $ CannonsQuantityString�6|   �� 5�   *   $��1��64   $��0 11 5 0q�6n   ��6D   �� $ BurningStringStatus�6n   5�   '   5�   #   5�      5�      5�      �� 5�      .+�5�      �� $��Center=�6    $��Bottom=�6=   
����p��$
��Bold"�6s   $��18(�6�   (&Управление моряками:6�   � 5�       5�      �� 5�      �� 5�       5�      �� 5�      �� 5�      .+�5�      �� $��0��6!   $��0��6.   $��3q�6>   
����p��$��10q�6n   $	��122��6z   $��45��6�   ._�5�      �� $	��123��6&   $��45��62   
�������$��Нанять��6R   $��12(�6c   $
��Bold"�6q   $��Center=�6�   $��Center=�6�   ��6�   �� *AddRandomCrewerCommand+5�      5�      �� 5�      $��1��6!   $��0��6.   $��3q�6>   
����p��$��10q�6n   $	��122��6z   $��45��6�   ._�5�      �� $	��123��6&   $��45��62   
�������$��Переобличить��6R   $��12(�6i   $
��Bold"�6w   $��Center=�6�   $��Center=�6�   ��6�   �� *RedactCrewerCommand+��6�   ��  �� ElementName$ ShipPartStatus��$ SelectedItem�5�      5�      �� 5�      $��0��6!   $��1��6.   $��3q�6>   
����p��$��10q�6n   $	��122��6z   $��45��6�   ._�5�      �� $	��123��6%   $��45��61   
�������$��Перетереть��6Q   $��12(�6f   $
��Bold"�6t   $��Center=�6�   $��Center=�6�   ��6�   �� *StatusCrewerCommand+��6�   �� $ ShipPartStatus��$ SelectedItem�5�      5�      �� 5�      $��1��6!   $��1��6.   $��3q�6>   
����p��$��10q�6n   $	��122��6z   $��45��6�   ._�5�      �� $	��123��6&   $��45��62   
�������$$��Выкинуть за борт��6R   $��12(�6m   $
��Bold"�6{   $��Center=�6�   $��Center=�6�   ��6�   �� *RemoveCrewerCommand+��6�   �� $ ShipPartStatus��$ SelectedItem�5�      5�      5�      �� 5�      $��Center=�6    $��Bottom=�6=   
����p��$
��Bold"�6s   $��18(�6�   &$Управление пушками:6�   � 5�       5�      �� 5�      �� 5�      .+�5�      �� $��	100 0 0 0q�6!   $��50��64   $��45��6?   
�������$��+��6_   $��30(�6k   $
��Bold"�6y   $��Center=�6�   $��Center=�6�   ��6�   �� *IncreaseCannonsQuantity+�� 5�      $��
-100 0 0 0q�6!   $��50��65   $��45��6@   
�������$��-��6`   $��30(�6l   $
��Bold"�6z   $��Center=�6�   $��Center=�6�   ��6�   �� *DecreaseCannonsQuantity+5�      5�      5�      � 5�      $��1��6    5�      �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'   �� 5�      $��* �6'    5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      �� 5�      .+�5�      �� $��6��6   $��1��6)   $��15 37 15 30q�66   
�������$��Палуба��6_   $��15(�6p   $��ShipPartStatus��6�   ��6~   �� *
DeckStatus+6�   �� 5�      $��2��6   $��2��6)   $��15 37 15 30q�66   
�������$��
Каюта��6_   $��15(�6o   $��ShipPartStatus��6�   ��6}   �� *CabinStatus+6�   �� 5�      $��4��6   $��0��6)   $��15 37 15 30q�66   
�������$��
Мачта��6_   $��15(�6o   $��ShipPartStatus��6�   ��6}   �� *
MastStatus+6�   �� 5�      $��2��6   $��0��6)   $��10 37 10 30q�66   
�������$!��Воронье Гнездо��6_   $��15(�6x   $��ShipPartStatus��6�   ��6�   �� *CrowsNestStatus+6�   �� 5�      $��6��6   $��3��6)   $��15 37 15 30q�66   
�������$��Камбуз��6_   $��15(�6p   $��ShipPartStatus��6�   ��6~   �� *GalleyStatus+6�   �� 5�      $��3��6   $��5��6)   $��	5 37 5 30q�66   
�������$��Сокровищница��6]   $��15(�6t   $��ShipPartStatus��6�   ��6�   �� *TreasureRoomStatus+6�   �� 5�      $��3��6   $��4��6)   $��
15 90 15 5q�66   
�������$��Добавить��6^   $��12(�6q   ��6   �� *IncreaseSlavesQuantity+�� 5�      $��5��6   $��3��6)   $��15 37 15 30q�66   
�������$��
Склад��6_   $��15(�6o   $��ShipPartStatus��6�   ��6}   �� *StockStatus+6�   �� 5�      $��5��6   $��3��6)   $��15,95,15,122q�66   
�������$%��Добавить Патроны��6`   $��12(�6{   $��ShipPartStatus��6�   $��2��6�   ��6�   �� *IncreaseAmmoQuantity+6�   �� 5�      $��5��6   $��4��6)   $��15,0,15,100q�66   
�������$��Добавить Еду��6_   $��12(�6v   $��ShipPartStatus��6�   ��6�   �� *IncreaseFoodQuantity+6�   �� 5�      $��2��6   $��5��6)   $��15 37 15 30q�66   
�������$��Сундук��6_   $��15(�6p   $��ShipPartStatus��6�   ��6~   �� *ChestStatus+6�   �� 5�      $��2��6   $��5��6)   $��
15 90 15 5q�66   
�������$��Добавить��6^   $��12(�6q   ��6   �� *IncreaseGoldQuantity+�� 5�      $��3��6   $��4��6)   $��15 37 15 30q�66   
�������$��Раб��6_   $��15(�6m   $��ShipPartStatus��6�   ��6{   �� *SlaveRoomStatus+6�   5�      5      5     5     