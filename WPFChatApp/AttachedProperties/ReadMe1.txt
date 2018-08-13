A tedious approach for specific property (vs a generic inherited one)

       public static readonly DependencyProperty MonitorPasswordProperty
          = DependencyProperty.RegisterAttached("MonitorPassword", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false, OnMonitorPasswordChanged));

       private static void OnMonitorPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
       {
           var passwordBox = (d as PasswordBox);

           if (passwordBox == null)
               return;
           passwordBox.PasswordChanged -= PasswordBox_PasswordChanged; //clean previous event

           if ((bool)e.NewValue)
           {
               SetHasText(passwordBox);
               passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
           }
       }

       private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
       {
           SetHasText((PasswordBox)sender);
       }

       public static void SetMonitorPassword(PasswordBox element, bool value)
       {
           element.SetValue(MonitorPasswordProperty, value);
       }

       public bool GetMonitorPassword(PasswordBox element)
       {
           return (bool)element.GetValue(MonitorPasswordProperty);
       }
       #endregion

       #region HasTextProperty
       public static readonly DependencyProperty HasTextProperty 
           = DependencyProperty.RegisterAttached("HasText", typeof(bool), typeof(PasswordBoxProperties), new PropertyMetadata(false));

       private static void SetHasText(PasswordBox element)
       {
           element.SetValue(HasTextProperty, element.SecurePassword.Length > 0);
       }

       public bool GetHasText(PasswordBox element)
       {
           return (bool)element.GetValue(HasTextProperty);
       }


