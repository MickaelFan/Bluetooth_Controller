   M S B A M L   `   `   `  ���� e  aMicrosoft.Web.WebView2.Wpf, Version=1.0.2849.39, Culture=neutral, PublicKeyToken=2a8ab48044d2601ekLclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.WpfMicrosoft.Web.WebView2.Wpf  O Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  	Bluetooth   Bluetooth.MainWindow   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     \wv2Lclr-namespace:Microsoft.Web.WebView2.Wpf;assembly=Microsoft.Web.WebView2.Wpf     6sys&clr-namespace:System;assembly=mscorlib       � Title$  Voiture transporteur��$	��450��$	��800�� � WindowStartupLocation$ CenterScreen=����#2C3E50
������� � SizeToContent$ WidthAndHeight=�$	��600��$	��400��.���  � ColumnDefinitions �� $��1* ��� $��2* �.+��� $��0��$��10q�.+�(� $	��200��$	��150��$��Center=�$��0,0,0,20q�.���� $��logo_ispm.png���� $��Voiture Transporteur��$��20(�$
��Bold"�
�������$��Center=�$	��Top=�$��	0,10,0,20q��� -    ��Name$ btnDiscover��$��
Rechercher��$	��250��$��40��$��	0,10,0,10q����#1ABC9C
�������$��14(�����  �� 
TargetType" ��.���  �� Property � �� �� Value ��  �� 
TargetType" ��.R��� 	 �� CornerRadius$	 20��#��z��#��z��$��1q�._��� $��Center=�$��Center=��� -   $ 
btnConnect��$��	Connecter��$	��250��$��40��$��	0,10,0,10q����#3498DB
�������$��14(����� " ��.���  � �� �� " ��.R��� $	 20��#��z��#��z��$��1q�._��� $��Center=�$��Center=��� -   
 ��Name$
 listBoxDevices��$	��250��$	��120��$��	0,10,0,10q����#34495E
�������$��12(����#2C3E50� $��	0,10,0,10q�.+��� -    ��Name$ txtUrl��$	��250��$��30��$��0,0,0,0q��� $�� ��
�������$��Center=�$
��Left=�$��5,0,0,0q� J� IsHitTestVisible$ False������ " �� �� Triggers ��  �� Binding �� *Text+ �� ElementName$ txtUrl�� �� Value  .a���  � y�$ Visible=���  �� *Text+$ txtUrl�� Z� .a���  � y�$ Visible=���  �� Empty# Z  �� *Text+$ txtUrl��.a���  � y�$ Visible=��� # Z  �� *Text+$ txtUrl��.a���  � y�$ 	Collapsed=��� -   $ 
btnLoadUrl��$��Afficher��$	��250��$��40�����#E67E22
�������$��14(����� " ��.���  � �� �� " ��.R��� $	 20��#��z��#��z��$��1q�._��� $��Center=�$��Center=�)   #Microsoft.Web.WebView2.Wpf.WebView2  -     Name$ 
webBrowser��$��1��$��10q�