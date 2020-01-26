 Wyższa Szkoła Ekonomii i Informatyki w Krakowie
„Programowanie obiektowe C# 2019/2020”
Projekt semestralny
Autorzy:
Marcin Chołda
Błażej Szosta 


1. Cel projektu

	Celem projektu jest stworzenie oraz rozwijanie aplikacji napisanej w środowisku Visual Studio 2019 przy pomocy języka programowania C#  oraz języku opisu interfejsu XAML. W ramach pracy wykorzystane zostaną zewnętrzne biblioteki „Dragablz”, „AspNetWebApi.SelfHost” oraz „Material Design Themes”. Dodatkowo, rozwój aplikacji ma być kontrolowany poprzez wykorzystanie systemu kontroli wersji Git oraz hostingowego serwisu internetowego github.

2. Realizacja projektu 

Cały kręgosłup aplikacji został oparty na plikach MainWindow.xaml oraz MainWindow.xaml.cs. 

   
     Okno aplikacji zostało wykonane ręcznie za pomocą kodu xaml oraz uzupełnione kodem funkcjonalnym c# w regionie TopRightCornerButtons:

protected void Window3Button_Click(object sender, RoutedEventArgs e)
        {
            Button btnSender = (Button)sender;
            if (btnSender.Name == "MaximizeButton")
            {
                if (this.WindowState == WindowState.Normal)
                    this.WindowState = WindowState.Maximized;
                else
                    this.WindowState = WindowState.Normal;
            }
            else if (btnSender.Name == "MinimizeButton")
                this.WindowState = WindowState.Minimized;
            else if(btnSender.Name == "TurnOffButton")
                this.Close();
        }



Cały projekt składa się z rozpisanych kolejno i wykonanych miniaplikacji:
	Templatka rachunku dla klienta (1)
	Prosta animacja „Akcelerator” (2)
	„Tic Tac Toe”(3)
	Chat P2P(4)
Dodatkowo w oknie About znajdują się informacje o autorach oraz link do github 

2.1 MainWindow.xaml
	
	Po załączeniu aplikacji znajdują się miniaplikacje (1), (2), (3) , które są przewidziane jako oddzielne okna xaml wywoływane po naciśnięciu na miniaturę.

	Od góry znajdują się karty Template, Chat, About, które są stworzone na podstawie zewnętrznej biblioteki Dragablz, odpowiednio zawarte w regionach „First App” , „Chat App”, „About”.

	Kod do chatu P2P znajduje się w regionie Chat w pliku MainWindow.xaml.cs
	
	Kod do pozostałych dwóch okien również znajduje się w MainWidnow.xaml.cs

2.1.1 Chat APP

Aplikacja P2P Chat niestety z uwagi na ograniczenia związane z routingiem i Api http będzie obecnie działać tylko w sieci lokalnej.  Niestety pakiety nie przejdą przez firewall, nie mówiąc o tym, że w protokole TCP potwierdzenie odebrania ramki nie będzie możliwe. Prawdopodobnie może zadziałać jako UDP.
	W ambitnych założeniach co też widać po pracy Błażeja widać że dopuszczano również mechanizm wymiany plików, to rozwiązanie zostanie opracowane na dalszym etapie rozwoju aplikacji
	Aplikacja po uruchomieniu domyślnie nie uruchamia self host (Microsoft.AspNet.WebApi.Client) dostarczonego przez nuget. Użytkownik musi wpisać swoją nazwę, swój port ( może być 900, lub nawet 25 jako brodecast), a także musi znać IP drugiej strony ( automatyzacja uzyskania połączenia jest kolejną TODO) 

Kliknięcie na połącz inicjuje chatProxy w klasie mainwindow, powoduje to aktywację okna wiadomości i powiadomienie o ewentualnych błędach. Inicjowany jest też self host.  Od tego monentu aplikacja faktycznie działa 

- do dalszego opracowania pozostaje lepsza obsługa wyjątków, łatwiejsza i po części automatyczna konfiguracja na podstawie wysłanego skrótu generowanego na podstawie danych użytkownika, lista kontaktów, archiwum wiadomości, które podlega szyfrowaniu.

2.1.2 Rachunek dla klienta

Po otworzeniu nowego okna ClientBill.xaml nie można wywołać odpowiedniej aplikacji bez  uzupełnienia wszystkich okien w formularzu.
Dopiero wtedy zostanie odblokuje to przycisk „submit”, który automatycznie uzupełnia dokument skryty za animacją.

Po uzupełnieniu w dolnym lewym rogu znajduje się przycisk, który pozwala wydrukować uzupełniony plik.

Logika znajduje się w oddzielnym pliku ClientBill.xaml.cs

2.1.3 Akcelerator

Po otworzeniu nowego okna  Accelerator.xaml  u góry znajduje się suwak, który wywołuje animację opartą na kodzie w Accelerator.xaml.cs
W kodzie wykorzystano INotifyPropertyChanged, a cały kod polega na aktywnej zmianie wartości Value oraz Angle.

2.1.4 Tic Tac Toe

Po otworzeniu nowego okna TicTacToe.xaml należy nacisnąć przycisk z ikoną startu co aktywuje grę, po zakończeniu gry jednemu z graczy zostaje przyznany punkt. Żeby ponownie rozpocząć  grę należy nacisnąć przycisk „Reset Game”.

Cała logika jest zawarte w pliku TicTacToe.xaml.cs 

Rozpoczęcie nowej gry załącza zdarzenie PlayButton_Click , które upewnia się, że wszystkie pola są puste oraz domyślnie ustawia turę gracza numer jeden jako pierwszą.
Po każdorazowym naciśnięciu przycisku tura graczy jest pomiędzy sobą przemieniana.
Każdorazowe naciśnięcie przycisku podpisanego  „TTTBoxButton” wywołuje dodatkowo sprawdzenie, czy ktoś nie wygrał, albo czy nie padł remis

CheckForWinner() Sprawdza, który zawodnik zwyciężył oraz uzupełnia tabelę wyników. 


