   M S B A M L   `   `   `  ????Q  MImportGraphObjectsTest, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:ImportGraphObjectsTestImportGraphObjectsTest  5   	   Q-clr-namespace:ImportGraphObjectsTest.ControlsImportGraphObjectsTest.Controls  5   	   #    ImportGraphObjects.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:ImportGraphObjectsTest     5   	   Bcoltrols-clr-namespace:ImportGraphObjectsTest.Controls     5   	     ? WindowStartupLocation$  CenterScreen=?5	   	    ? Title$ Ipmort objects??5
   	   $	??500??5   	   $	??500??5   	   $	??450??5   	   $	??800??6    ? 	Resources 5       ?? MergedDictionaries ?? Source?? 5   
    5      ?? 5      $3 -/ImportGraphObjectsTest;component/Styles.xaml??6%   %    5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $??* ?6   ?? 5      $
??auto ?6   .+?5   
   ? $??0??6   .+?5      ??  ?? Orientation$ 
Horizontal=?6   .+?5      ?? $??
Import csv??6   $
??Auto??5      $??5q?5          ButtonLightStyle#??[  5!      ??5"      ?? *ImportCSV_Commmand+?? 5$      $??Import xls/xlsx??6   $
??Auto??5%      $??5q?5&      #??[  5'      ??5(      ?? *ImportXLS_Commmand+5*      5+      ? 5,   
   $??1??6   .+?5-      ?  ? ColumnDefinitions 5.      ?? 5/      $??* ?6'   ?? 50      $
??Auto ?6'   ?? 51      $??* ?6'   .+?53      ? $??0??6   .+?54      &   System.Windows.Controls.DataGrid   %? IsVirtualizing$
 True??55        DataGridStyle#??[ 58      $??5q?59      ??56      ?? *ObjectsImport+	 ?? SelectedItem	 57      ?? *SelectedObject+
   Columns
 5;      0  *System.Windows.Controls.DataGridTextColumn  5=      ,  &System.Windows.Controls.DataGridColumn   Header$
 Name??61      MinWidth$	 100Q?6}      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6?   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   ?? *Name+ ?? UpdateSourceTrigger$ PropertyChanged=?6?     5>      $ Distance??61    6C   ?? *
Distance+ ?? Mode$ TwoWay=?$ PropertyChanged=? ?? StringFormat$ {0:N1}??  5?      $ Angle??61    6@   ?? *Angle+$ PropertyChanged=?$ {0:N1}??  5@      $ Width??61    6@   ?? *Width+$ PropertyChanged=?$ {0:N1}??  5A      $ Hegth??61    6@   ?? *Hegth+$ PropertyChanged=?$ {0:N1}??4  .System.Windows.Controls.DataGridTemplateColumn  5B      $ IsDefect??65   $
 Auto 6G      CellTemplate 5C   "   ?? 5D   &   .R?5E   *   ? .+?5F   .   ??  d? 	IsChecked 67   ?? *
IsDefect+$ TwoWay=?$ PropertyChanged=?5G   +   5H   '   5J      5L      5M      ? 5N      -   5         ?Name$ splitter??5P      $??1??5O      .+?5Q      ?? $??5??6#   ???	#FFBDE0FF$??Stretch=?5S   #   $??Center=?5T   #   5U      ? 5W      -   5        $ 	gridRight??5X      $??2??5W       5Z      ?? 5[      $
??Auto ?6(   ?? 5\      $??* ?6(   .+?5^      ?? $??0??5_      $??1,1,1,0q?5`      
???????$??5q?5b      ._?5c      ?? ??5d   !   ?? *SelectedObjectParams+??5e      ?? 5f   "   .R?5g   &   ?? $??0,0,0,1q?5h   -   
???????._?5j   *   ?? $ 
Horizontal=?65   .+?5k   .   ?? $
??Bold"?5l   5   $	??100??5m   5   $??5q?5n   5   ??5k   8   ?? *Name+$ {0:G}:??5n   5   ?? 5o   .   $??5q?5p   5   ??5o   8   ?? *Value+5p   5   5q   +   5r   '   5s   #   5u      5v      ? 5w      -   5        $??	gridGraph??5y      $??1??5x      $??5q?5z      .+?5{      2   ,ImportGraphObjectsTest.Controls.GraphControl  $??Stretch=?5|      $??Stretch=?5}         ObjectsDraw 5~      ?? *ObjectsImport+5      5?      5?      5?      ? 5?   
   $??2??6   5?      5?      5?      