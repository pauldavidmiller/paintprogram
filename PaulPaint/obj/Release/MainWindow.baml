   M S B A M L   `   `   `  ����   	PaulPaint    PaulPaint.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006       � Title$  Image Editor��$	��500��$
��1000�� � 
ResizeMode$ 	CanResize=�   mainIcon � Icon# �   .���  � ColumnDefinitions �� $��4* ��� $��5 ��� $��* �$��35��$	��200��.+�� $��0�� � RowDefinitions �� $��* ��� $��35 �.+�� $��0��
�������.+��� 
���   �$��2q��� -   $��paintSurface��.+��� -   $��importImage��$
��Fill=�$
��Left=�$	��Top=����� *	imagePath+� $��1��
�������.+��� 
���   �$��1q��� -   $��btnOpenImage��$
��Open��$��Right=�$��Center=�$��50��$��25��$��0,0,70,0q��� -   $��btnSaveImage��$
��Save��$��Right=�$��Center=�$��50��$��25��$��	0,0,10, 0q��� -   $��btnClearImage��$��Clear��$
��Left=�$��Center=�$��10,0,0,0q�$��50��$��25���� $��1��$��Stretch=�
�������� $��2�� �� $��* ��� $��* �.+��� -   $��m_ColorList��$��0��.@��� -   .��� $��1,1,1,1q� �� $��20 ��� $��* �.+�� $��0��.+���  
 select#���  $��20��$��20��� $��1��$��10,5,0,5q�.+��� $
��Edit���� -   .��� $��1,1,1,1q� �� $��20 ��� $��* �.+�� $��0��.+��� 
���   �� $��1��$��10,5,0,5q�.+��� $��Black Paintbrush���� -	   .��� $��1,1,1,1q� �� $��20 ��� $��* �.+�� $��0��.+��� 
����  �� $��1��$��10,5,0,5q�.+��� $��Blue Paintbrush���� -
   .��� $��1,1,1,1q� �� $��20 ��� $��* �.+�� $��0��.+��� 
���  ��� $��1��$��10,5,0,5q�.+��� $��Red Paintbrush���� -   .��� $��1,1,1,1q� �� $��20 ��� $��* �.+�� $��0��.+��� 
��� � �� $��1��$��10,5,0,5q�.+��� $��Green Paintbrush���� -   .��� $��1,1,1,1q� �� $��20 ��� $��* �.+�� $��0��.+��� 
��� ���� $��1��$��10,5,0,5q�.+��� $��Yellow Paintbrush���� -   $��m_ThicknessList��$��1��.@��� -   .��� $��1,1,1,1q� �� $��20 ��� $��* �.+�� $��0��.+���   
thickness1#���  $��20��$��20��� $��1��$��10,5,0,5q�.+��� $��Thickness #1���� -   .��� $��1,1,1,1q� �� $��20 ��� $��* �.+�� $��0��.+���   
thickness2#���  $��20��$��20��� $��1��$��10,5,0,5q�.+��� $��Thickness #2���� -   .��� $��1,1,1,1q� �� $��20 ��� $��* �.+�� $��0��.+���   
thickness3#���  $��20��$��20��� $��1��$��10,5,0,5q�.+��� $��Thickness #3��