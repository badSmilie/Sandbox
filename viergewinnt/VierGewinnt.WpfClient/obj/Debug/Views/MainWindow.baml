   M S B A M L   `   `   `  ����P  LVierGewinnt.WpfClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullrMclr-namespace:VierGewinnt.WpfClient.SampleData;assembly=VierGewinnt.WpfClient VierGewinnt.WpfClient.SampleData  5   	   =#clr-namespace:VierGewinnt.WpfClientVierGewinnt.WpfClient  5   	   &     VierGewinnt.WpfClient.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   d
SampleDataMclr-namespace:VierGewinnt.WpfClient.SampleData;assembly=VierGewinnt.WpfClient     5   	   5local#clr-namespace:VierGewinnt.WpfClient     5   	     � WindowState$  	Maximized=�5	   	    � Title$ Vier Gewinnt��5
   	   $
��1000��6   $
��1900��6,    � 	Resources 5       �� DataType*   $VierGewinnt.WpfClient.SpielViewModel%   VierGewinnt.WpfClient.SpielView.   (VierGewinnt.WpfClient.StartPageViewModel%   VierGewinnt.WpfClient.StartPage   ListBoxMenuItemTemplate �� 
TargetType  ListBoxSpalteMenuStyle �� 
TargetType �� Property �� Value  ListBoxMenuStyle � ColumnDefinitions��%4  (��       5      *, +)(�� 2     5      *, +)&	  d     &	     7   &	 m    7  �� 5   
   "  6   .R�5        5      �� 5   
   "  6   .R�5        5      �� 5   
   " ��6:   .R�5      �� #��z��5      #��z��5      #��z��5      #��z��5      ��5      �� *Name+��5      �� 5      �� 5   
   " ��6/   .�5      ��  � ��8   6)   �� 5        � �� 6,   �� *SpaltenIndex+�� 5!       � ��$ Stretch=�6;   �� 5"       � ��$ Center=�69   �� 5#       � ��$ 7.5 0q�6(   �� 5$       � ��$ 60��6'   �� 5%       � ��$ Segoe UI Symbol)�6+   �� 5&       � ��$ 20(�6)   5'      �� 5)   
   " ��6)   .�5*      ��  � ��$ 0 0 0 0q�6'   �� 5+       � ��
 ���� 6+   �� 5,       � �� 6,   Z� �� 5-       � ��$ 90��6'   �� 5.       � �� 5/      �� 50      .R�51      �  52      �� 53   "   �� 54   "   �� 55   "   57      58      5:      �� 5;       � ��8   63   5<      5=      .��5?      � $��30q�6   	 � RowDefinitions	 5@   
   �� 5A      $��* �6   �� 5B      $��70 �6    5D   
   �� 5E      $��* �6   .+�5G   
   �� $��0��6   $��0��6&   ��66   �� *	ViewModel+�� 5H   
   $��1��6   $��0��6   #��[ 6T   ��6/   �� *MenuCommands+6T   5I      5J      