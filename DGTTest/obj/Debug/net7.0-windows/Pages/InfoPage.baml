   M S B A M L   `   `   `  ����B  >DGTTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:DGTTestDGTTest  5          DGTTest.InfoPage   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      'localclr-namespace:DGTTest     5        N� Title$  InfoPage��5      $	��450��6   $	��800��6%   .��5
      �  � RowDefinitions 5      �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $
��Auto �6   �� 5   
   $��* �6   .+�5      �� $��1��6   $��10q�6   $��20(�6)   $
��Bold"�67   ��6I   �� *Currency.Name+�� 5      $��2��6   $��10q�6   .+�5   
   �� $��Price (USD):��6   $��	0,5, 5, 5q�6)   $��Medium"�6<   �� 5   
   ��6   �� *Currency.PriceUsd+�� 5   
   $��Volume (USD/24 Hours):��6   $��
0, 5, 5, 5q�62   $��Medium"�6F   �� 5   
   ��6   �� *Currency.VolumeUsd24Hr+�� 5   
   $ ��Price Change (%/24 Hours):��6   $��
0, 5, 5, 5q�66   $��Medium"�6J   �� 5   
   ��6   �� *Currency.ChangePercent24Hr+5      �� 5      $��3��6   $��10q�6   ��6(   �� *Currency.Markets+ �� View 5   
   �� 5      .P�5       �� $��Market Name��6!    �� DisplayMemberBinding 66   �� *
ExchangeId+�� 5!      $��PriceUSD��6!    63   �� *
PriceUsd+�� 5"      $	��URL��6!    6.   �� *ExchangeUrl+5#      5%      5&      5'      