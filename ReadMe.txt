Exception Handling in WPF Anwendungen

Nicht abgefangene Exception können zu einem unangenehmen Problem werden. Vor allem wenn man nicht weiß wo man den try catch Block setzen soll z.B. bei Bindings in WPF Controls. Abhilfe kann Dispatcher.UnhandledException schaffen:

        Dispatcher.UnhandledException += OnDispatcherUnhandledException;

        ...

        void OnDispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(e.Exception.Message,"OnDispatcherUnhandledException");
            e.Handled = true;
        }
			
Die erste Zeile kann man in den Konstruktor der class App : Application einer WPF Anwendung stecken OnDispatcherUnhandledException muss dann eine Memberfunktion der der class App werden.

Hat man es mit Exception in einem Working-Thread zu tun kann man AppDomain.CurrentDomain.UnhandledException setzen:

        AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(OnCurrentDomainUnhandledException);

        ...

        void OnCurrentDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            MessageBox.Show(((Exception)e.ExceptionObject).Message,"OnCurrentDomainUnhandledException");
        }

bei der Implementation gilt gleiches wie oben. Was einem natürlich keiner erzählt das letzteres die Anwendung nicht vor dem Absturz bewahrt, man kann lediglich noch eine Meldung ausgeben.

		