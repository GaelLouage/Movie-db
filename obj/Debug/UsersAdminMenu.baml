   M S B A M L   `   `   `  ????H  DMovieDatabase, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:MovieDatabaseMovieDatabase  5   	   "    MovieDatabase.UsersAdminMenu   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:MovieDatabase     5   	     ? Title$  UsersAdminMenu??5   	   $	??450??6    $	??800??6-   ???	#FF232323.??5	      ?  ? ColumnDefinitions 5
   
   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6   ?? 5      $??* ?6    ? RowDefinitions 5   
   ?? 5      $
??auto ?6   .+?5   
   ?? $??Edit user roles??6   
???????.??5      ?? .+?5      ?? -   5         ??Name$ cmbUsersRoleEdit??5      ??5      ?? 5      .R?5      ?? .+?5   "   ??  ?? Orientation$ 
Horizontal=?6-   .+?5   &   ?? $??	Username:??60   $
??Bold"?6A   $??10 10 10 10q?6S   ?? 5   &   
???   ?$??10 10 10 10q?6^   ??60   ?? *	firstName+6^   5   #   ?? 5   "   $ 
Horizontal=?6-   .+?5    &   ?? $??Role:??60   $
??Bold"?6=   $??10 10 10 10q?6O   ?? 5!   &   $??10 10 10 10q?6J   ??60   ?? *
userRole+6J   5"   #   ?? 5#   "   5$      5&      5(      	? 5)      -   5         	?Name$ rdbAdmin??5)      $??Admin??60   
???????$??16(?6S   $??5 5 5 5q?6a   6r   	? 5*      -   5        $ rdbUser??5*      $
??User??6/   
???????$??16(?6Q   $??5 5 5 5q?6_   6p   5+      5,      5.      5/      