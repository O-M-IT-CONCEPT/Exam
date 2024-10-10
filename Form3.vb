﻿Imports System.Data.SqlClient
Imports System.IO

Public Class Form3
    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With ComboBox2
            .Items.AddRange(New String() {
            "ABUJA", "ABIA", "ADAMAWA", "AKWA IBON", "ANAMBRA", "BAUCHI", "BAYELSA",
            "BENUE", "BORNO", "CROSS RIVER", "DELTA", "EDO", "EBONYI", "EKITI",
            "ENUGU", "GOMBE", "IMO", "JIGAWA", "KADUNA", "KANO", "KATSINA",
            "KEBBI", "KOGI", "KWARA", "LAGOS", "NIGER", "OGUN", "ONDO",
            "OSUN", "OYO", "NASSARAWA", "PLATEAU", "RIVERS", "SOKOTO", "TARABA",
            "YOBE", "ZAMFARA"
        })
        End With
        Dim lastId As Integer = 0
        Dim sql As String = "SELECT TOP 1 ID FROM staff ORDER BY ID DESC"
        Dim dt As DataTable = Crud(sql, Nothing)
        If dt.Rows.Count > 0 Then
            lastId = Convert.ToInt32(dt.Rows(0)("ID"))
        End If
        Dim nextId As Integer = lastId + 1
        Dim sid As String = $"FPO/{Today.ToString("yyyy-MM-dd")}/{nextId:D6}"
        TextBox11.Text = sid
    End Sub

    Private Sub ComboBox2_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox2.SelectedIndexChanged
        With ComboBox3
            If ComboBox2.Text = "ABUJA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Gwagwalada")
                .Items.Add("Kuje")
                .Items.Add("Abaji")
                .Items.Add("Abuja municipal")
                .Items.Add("Bwari")
                .Items.Add("Kwali")
            ElseIf ComboBox2.Text = "ABIA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Aba north")
                .Items.Add("Aba south")
                .Items.Add("Arochukwu")
                .Items.Add("Bende")
                .Items.Add("Ikwuano")
                .Items.Add("Isiala-Ngwa North")
                .Items.Add("Isiala-Ngwa South")
                .Items.Add("Isuikwato")
                .Items.Add("Obi Nwa")
                .Items.Add("Ohafia")
                .Items.Add("Osisioma")
                .Items.Add("Ngwa")
                .Items.Add("Ugwunagbo")
                .Items.Add("Ukwa east")
                .Items.Add("Ukwa west")
                .Items.Add("Umuahia north ")
                .Items.Add("Umuahia north")
                .Items.Add("Umu neochi")
            ElseIf ComboBox2.Text = "ADAMAWA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Dmsa")
                .Items.Add("Fufore")
                .Items.Add("Ganaye")
                .Items.Add("Gireri")
                .Items.Add("Gombi")
                .Items.Add("Guyuk")
                .Items.Add("Hong")
                .Items.Add("Jade")
                .Items.Add("Lamurde")
                .Items.Add("Madagali")
                .Items.Add("Maiha")
                .Items.Add("Myo-Belwa")
                .Items.Add("Michika")
                .Items.Add("Mubi north")
                .Items.Add("Mubi south")
                .Items.Add("Numan")
                .Items.Add("Shelleng")
                .Items.Add("Song")
                .Items.Add("Toungo")
                .Items.Add("Yola North")
                .Items.Add("Yola South")
            ElseIf ComboBox2.Text = "AKWA IBON" Then
                ComboBox3.Items.Clear()
                .Items.Add("Abk")
                .Items.Add("Easter Obolo")
                .Items.Add("Eket")
                .Items.Add("Esit Eket")
                .Items.Add("Essien Udim")
                .Items.Add("Etin Ekpo")
                .Items.Add("Etinano")
                .Items.Add("Ibeno")
                .Items.Add("Ibeskipo Asutan")
                .Items.Add("Ibiono Ibom")
                .Items.Add("Ika")
                .Items.Add("Ikono")
                .Items.Add("Ikot Abasi")
                .Items.Add("Ikot Ekpene")
                .Items.Add("Ini")
                .Items.Add("Itu")
                .Items.Add("Mbo")
                .Items.Add("Mbo")
                .Items.Add("Mkpat Enin")
                .Items.Add("Nsit Atai")
                .Items.Add("Nsit Ibom")
                .Items.Add("Nsit Ubium")
                .Items.Add("Obot Akara")
                .Items.Add("Okobo")
                .Items.Add("Onna")
                .Items.Add("Oron")
                .Items.Add("Oruk Anam")
                .Items.Add("Udung Uko")
                .Items.Add("Ukanafun")
                .Items.Add("Uruan")
                .Items.Add("Urue-Offong/oruko")
                .Items.Add("Uyo")
            ElseIf ComboBox2.Text = "ANAMBRA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Aguata")
                .Items.Add("Anambra East")
                .Items.Add("Anambra West")
                .Items.Add("Anaocha")
                .Items.Add("Awka North")
                .Items.Add("Ayemelum")
                .Items.Add("Dunukofia")
                .Items.Add("ekwusigo")
                .Items.Add("Idemili north")
                .Items.Add("Idemili south")
                .Items.Add("Ihiala")
                .Items.Add("Njikoka")
                .Items.Add("Nnewi north")
                .Items.Add("Nnewi south")
                .Items.Add("Ogbru")
                .Items.Add("Onitsha North")
                .Items.Add("Onitsha South")
                .Items.Add("Orumba North")
                .Items.Add("Orumba South")
                .Items.Add("Oyi")
            ElseIf ComboBox2.Text = "BAUCHI" Then
                ComboBox3.Items.Clear()
                .Items.Add("Alkaleri")
                .Items.Add("Bauchi")
                .Items.Add("Bogoro")
                .Items.Add("Damban")
                .Items.Add("Darazo")
                .Items.Add("Dass")
                .Items.Add("Ganjuwa")
                .Items.Add("Giade")
                .Items.Add("Itas/Gadau")
                .Items.Add("Jama'are")
                .Items.Add("Katagum")
                .Items.Add("Kirfi")
                .Items.Add("Misau")
                .Items.Add("Ningi")
                .Items.Add("Shira")
                .Items.Add("Tafawa Balewa")
                .Items.Add("Toro")
                .Items.Add("Warji")
                .Items.Add("Zaki")
            ElseIf ComboBox2.Text = "BAYELSA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Brass")
                .Items.Add("Ekeremor")
                .Items.Add("Kolokuma/opokuma")
                .Items.Add("Nembe")
                .Items.Add("Ogbia")
                .Items.Add("Sagbama")
                .Items.Add("Southern Jaw")
                .Items.Add("Yenegoa")
            ElseIf ComboBox2.Text = "BENUE" Then
                ComboBox3.Items.Clear()
                .Items.Add("Ado")
                .Items.Add("Agatu")
                .Items.Add("Apa")
                .Items.Add("Buruku")
                .Items.Add("Gwer East")
                .Items.Add("Gwer West")
                .Items.Add("Katsina-Ala")
                .Items.Add("Konshisha")
                .Items.Add("kwande")
                .Items.Add("Logo")
                .Items.Add("Makurdi")
                .Items.Add("Obi")
                .Items.Add("Ogbadibo")
                .Items.Add("Oju")
                .Items.Add("Okpokwu")
                .Items.Add("Ohimini")
                .Items.Add("Oturkpo")
                .Items.Add("Tarka")
                .Items.Add("Ukum")
                .Items.Add("Ushongo")
                .Items.Add("Vandeikya")
            ElseIf ComboBox2.Text = "BORNU" Then
                ComboBox3.Items.Clear()
                .Items.Add("Abadam")
                .Items.Add("Askira/Uba")
                .Items.Add("Bama")
                .Items.Add("Bayo")
                .Items.Add("Biu")
                .Items.Add("Chibok")
                .Items.Add("Damboa")
                .Items.Add("Dikwa")
                .Items.Add("Gubio")
                .Items.Add("Guzamala")
                .Items.Add("Gwoza")
                .Items.Add("Hawul")
                .Items.Add("Jere")
                .Items.Add("Kaga")
                .Items.Add("Kala/Balge")
                .Items.Add("Konduga")
                .Items.Add("kukawa")
                .Items.Add("Kwaya Kusar")
                .Items.Add("Mafa")
                .Items.Add("Magumeri")
                .Items.Add("maiduguri")
                .Items.Add("Marte")
                .Items.Add("Mobbar")
                .Items.Add("Monguno")
                .Items.Add("Ngala")
                .Items.Add("Nganzai")
                .Items.Add("Shani")
            ElseIf ComboBox2.Text = "CROSS RIVER" Then
                ComboBox3.Items.Clear()
                .Items.Add("Akpabuyo")
                .Items.Add("Odukpani")
                .Items.Add("Akamkpa")
                .Items.Add("Abi")
                .Items.Add("Ikom")
                .Items.Add("Yarkur")
                .Items.Add("Odubra")
                .Items.Add("Boki")
                .Items.Add("Ogoja")
                .Items.Add("Yala")
                .Items.Add("Obaniku")
                .Items.Add("Obudu")
                .Items.Add("Calabar South")
                .Items.Add("Etung")
                .Items.Add("Bekwara")
                .Items.Add("Bakassi")
                .Items.Add("Calabar")
                .Items.Add("Municipality")
            ElseIf ComboBox2.Text = "DELTA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Oshimili")
                .Items.Add("Aniocha")
                .Items.Add("Aniocha South")
                .Items.Add("Ika south")
                .Items.Add("Ika North-east")
                .Items.Add("Ndokwa West")
                .Items.Add("Ndokwa east")
                .Items.Add("Isoko South")
                .Items.Add("Isoko north")
                .Items.Add("Bomadi")
                .Items.Add("Burutu")
                .Items.Add("Ughelli South")
                .Items.Add("Ughelli North")
                .Items.Add("Ethiope West")
                .Items.Add("Ethiope East")
                .Items.Add("Sapele")
                .Items.Add("Okpe")
                .Items.Add("Warri north")
                .Items.Add("Warri south")
                .Items.Add("Uvwie")
                .Items.Add("Udu")
                .Items.Add("Warri Central")
                .Items.Add("Ukwani")
                .Items.Add("Oshimil North")
                .Items.Add("Patani")
            ElseIf ComboBox2.Text = "EBONYI" Then
                ComboBox3.Items.Clear()
                .Items.Add("Afikpo South")
                .Items.Add("Afikpo North")
                .Items.Add("OnichA")
                .Items.Add("Ohaozara")
                .Items.Add("Abakaliki")
                .Items.Add("Ishielu")
                .Items.Add("Ikwo")
                .Items.Add("Ezza")
                .Items.Add("Ezza South")
                .Items.Add("Ohaukwu")
                .Items.Add("Ebonyi")
                .Items.Add("Ivo")
            ElseIf ComboBox2.Text = "EDO" Then
                ComboBox3.Items.Clear()
                .Items.Add("Esan North East")
                .Items.Add("Esan Central")
                .Items.Add("Esan West")
                .Items.Add("Egor")
                .Items.Add("Ukpoba")
                .Items.Add("Central")
                .Items.Add("Etsako Central")
                .Items.Add("Igueben")
                .Items.Add("Oredo")
                .Items.Add("ovia South West")
                .Items.Add("ovia South East")
                .Items.Add("Orhionwon")
                .Items.Add("Uhunmwonde")
                .Items.Add("Etsako East")
                .Items.Add("Etsako South-East")
            ElseIf ComboBox2.Text = "EKITI" Then
                ComboBox3.Items.Clear()
                .Items.Add("Ado")
                .Items.Add("Ekiti-East")
                .Items.Add("Ekiti-West")
                .Items.Add("Emure/Ise/Orun")
                .Items.Add("Ekiti South-West")
                .Items.Add("Ikare")
                .Items.Add("Irepodun")
                .Items.Add("Ijero")
                .Items.Add("Ido/Osi")
                .Items.Add("Oye")
                .Items.Add("Ikole")
                .Items.Add("Moba")
                .Items.Add("Gbonyin")
                .Items.Add("Efon")
                .Items.Add("Ise/Orun")
                .Items.Add("Ilejemeje")
            ElseIf ComboBox2.Text = "ENUGU" Then
                ComboBox3.Items.Clear()
                .Items.Add("Enugu South")
                .Items.Add("Igbo-Eze South")
                .Items.Add("Enugu North")
                .Items.Add("Nkanu")
                .Items.Add("Udi Agwu")
                .Items.Add("Oji River")
                .Items.Add("Ezeagu")
                .Items.Add("Igbo Eze North")
                .Items.Add("Isi-Uzo")
                .Items.Add("Nsukka")
                .Items.Add("Igbo-Ekiti")
                .Items.Add("Uzo-Uwani")
                .Items.Add("Enugu Eas")
                .Items.Add("Aninri")
                .Items.Add("Nkanu East")
                .Items.Add("Udenu")
            ElseIf ComboBox2.Text = "GOMBE" Then
                ComboBox3.Items.Clear()
                .Items.Add("Akko")
                .Items.Add("Balanga")
                .Items.Add("Biliri")
                .Items.Add("Dkku")
                .Items.Add("Kaltungo")
                .Items.Add("Kwami")
                .Items.Add("Shomgom")
                .Items.Add("Funakaye")
                .Items.Add("Gombe")
                .Items.Add("Nafada/Bajoga")
                .Items.Add("Yamaltu/Delta")
            ElseIf ComboBox2.Text = "IMO" Then
                ComboBox3.Items.Clear()
                .Items.Add("Aboh-Mbaise")
                .Items.Add("Ahiazu-Mbaise")
                .Items.Add("Ehime-Mbano")
                .Items.Add("Ezinihitte")
                .Items.Add("Ideato North")
                .Items.Add("Ideato South")
                .Items.Add("Ihitte/Uboma")
                .Items.Add("Ikeduru")
                .Items.Add("Isiala Mbano")
                .Items.Add("Isu")
                .Items.Add("Mbaitoli")
                .Items.Add("Ngor-Okpala")
                .Items.Add("Njaba")
                .Items.Add("Nwangele")
                .Items.Add("Nkwerre")
                .Items.Add("Obowo")
                .Items.Add("Oguta")
                .Items.Add("Ohaji/Egbema")
                .Items.Add("Okigwe")
                .Items.Add("Orlu")
                .Items.Add("Orsu")
                .Items.Add("Oru East")
                .Items.Add("Oru West")
                .Items.Add("Owerri-municipal")
                .Items.Add("Owerri North")
                .Items.Add("Owerri West")
            ElseIf ComboBox2.Text = "JIGAWA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Auyo")
                .Items.Add("Babura")
                .Items.Add("Birni Kudu")
                .Items.Add("Biriniwa")
                .Items.Add("Buji")
                .Items.Add("Dutse")
                .Items.Add("Gagarawa")
                .Items.Add("Garki")
                .Items.Add("Gumel")
                .Items.Add("Guri")
                .Items.Add("Gwaram")
                .Items.Add("Gwiwa")
                .Items.Add("Hadejia")
                .Items.Add("Jahun")
                .Items.Add("Kafin Hausa")
                .Items.Add("Kaugama Kazaure")
                .Items.Add("Kiri Kasamma")
                .Items.Add("Kiyawa")
                .Items.Add("Maigatari")
                .Items.Add("Malam Madori")
                .Items.Add("Miga")
                .Items.Add("Ringim")
                .Items.Add("Roni")
                .Items.Add("Sule-Tankarkar")
                .Items.Add("Taura")
                .Items.Add("Yankwashi")
            ElseIf ComboBox2.Text = "KADUNA" Then
                ComboBox3.Items.Clear()
                .Items.Add("birni-Gwari")
                .Items.Add("Chikun")
                .Items.Add("Giwa")
                .Items.Add("Igabi")
                .Items.Add("Ikara")
                .Items.Add("Jaba")
                .Items.Add("Jema'a")
                .Items.Add("Kachia")
                .Items.Add("Kaduna North")
                .Items.Add("Kaduna South")
                .Items.Add("Kagarko")
                .Items.Add("Kajuru")
                .Items.Add("Kaura")
                .Items.Add("Kauru")
                .Items.Add("Kubau")
                .Items.Add("Kudan")
                .Items.Add("Lere")
                .Items.Add("Makarfi")
                .Items.Add("Sabon-Gari")
                .Items.Add("Sanga")
                .Items.Add("Soba")
                .Items.Add("Zango-Kataf")
                .Items.Add("Zarial")
            ElseIf ComboBox2.Text = "KANO" Then
                ComboBox3.Items.Clear()
                .Items.Add("Ajingi")
                .Items.Add("Albasu")
                .Items.Add("Bagwai")
                .Items.Add("Bebeji")
                .Items.Add("Bichi")
                .Items.Add("Bunkure")
                .Items.Add("Dala")
                .Items.Add("Dambatta")
                .Items.Add("Dawakin Kudu")
                .Items.Add("Dawakin Tofa")
                .Items.Add("Doguwa")
                .Items.Add("Fagge")
                .Items.Add("Gabasawa")
                .Items.Add("Garko")
                .Items.Add("Garum")
                .Items.Add("Mallam")
                .Items.Add("Gaya")
                .Items.Add("Gezawa")
                .Items.Add("Gwale")
                .Items.Add("Gwarzo")
                .Items.Add("Kabo")
                .Items.Add("kano Municipal")
                .Items.Add("Karaye")
                .Items.Add("Kibiya")
                .Items.Add("Kiru")
                .Items.Add("Kumbotso")
                .Items.Add("Kunchi")
                .Items.Add("Kura")
                .Items.Add("Madobi")
                .Items.Add("Makoda")
                .Items.Add("Minijibir")
                .Items.Add("Nasarawa")
                .Items.Add("Rano")
                .Items.Add("Rimin Gado")
                .Items.Add("Rogo")
                .Items.Add("Shanono")
                .Items.Add("Sumaila")
                .Items.Add("Takali")
                .Items.Add("Tarauni")
                .Items.Add("Tofa")
                .Items.Add("Tsanyawa")
                .Items.Add("Tudun Wada")
                .Items.Add("Ungogo")
                .Items.Add("Warawa")
                .Items.Add("Wudil")
            ElseIf ComboBox2.Text = "KATSINA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Bakori")
                .Items.Add("Batagarawa")
                .Items.Add("Batsari")
                .Items.Add("Baure")
                .Items.Add("Bindawa")
                .Items.Add("Charanchi")
                .Items.Add("Dandume")
                .Items.Add("Danja")
                .Items.Add("Dan Musa")
                .Items.Add("Daura")
                .Items.Add("Dutsi")
                .Items.Add("Dutsin-Ma")
                .Items.Add("Faskari")
                .Items.Add("Funtua")
                .Items.Add("Ingawa")
                .Items.Add("Funtua")
                .Items.Add("Ingawa")
                .Items.Add("Jibia")
                .Items.Add("Kafur")
                .Items.Add("Kaita")
                .Items.Add("Kankara")
                .Items.Add("Kankia")
                .Items.Add("Katsina")
                .Items.Add("Kurfi")
                .Items.Add("Mai'Adua")
                .Items.Add("Malumfashi")
                .Items.Add("Mani")
                .Items.Add("Mashi")
                .Items.Add("Matazuu")
                .Items.Add("Musawa")
                .Items.Add("Rimi")
                .Items.Add("Sabuwa")
                .Items.Add("Safana")
                .Items.Add("Sandamu")
                .Items.Add("Zango")
            ElseIf ComboBox2.Text = "KEBBI" Then
                ComboBox3.Items.Clear()
                .Items.Add("Aleiro")
                .Items.Add("Arewa-Dandi")
                .Items.Add("Argungu")
                .Items.Add("Augie")
                .Items.Add("Bagudo")
                .Items.Add("Birnin Kebbi")
                .Items.Add("Bunza")
                .Items.Add("Dandi")
                .Items.Add("Fakai")
                .Items.Add("Gwandu")
                .Items.Add("Jega")
                .Items.Add("Kalgo")
                .Items.Add("Koko/Besse")
                .Items.Add("Maiyama")
                .Items.Add("Ngaski")
                .Items.Add("Sakaba")
                .Items.Add("Shanga")
                .Items.Add("Suru")
                .Items.Add("Wasagu/Danko")
                .Items.Add("Yauri")
                .Items.Add("Zuru")
            ElseIf ComboBox2.Text = "KOGI" Then
                ComboBox3.Items.Clear()
                .Items.Add("Adavi")
                .Items.Add("Ajaokuta")
                .Items.Add("Ankpa")
                .Items.Add("Bassa")
                .Items.Add("Dekina")
                .Items.Add("Ibaji")
                .Items.Add("Idah")
                .Items.Add("Igalamela-Odolu")
                .Items.Add("Ijumu")
                .Items.Add("Kabba/Bunu")
                .Items.Add("Kogi")
                .Items.Add("Lokoja")
                .Items.Add("Mopa-Muro")
                .Items.Add("Ofu")
                .Items.Add("Ogori/Mangongo")
                .Items.Add("Okehi")
                .Items.Add("Okene")
                .Items.Add("Olamabolo")
                .Items.Add("omala")
                .Items.Add("Yagba East")
                .Items.Add("Yagba West")
            ElseIf ComboBox2.Text = "KWARA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Asa")
                .Items.Add("Baruten")
                .Items.Add("Edu")
                .Items.Add("Ekiti")
                .Items.Add("Ifelodun")
                .Items.Add("Ilorin east")
                .Items.Add("Ilorin West")
                .Items.Add("Irepodun")
                .Items.Add("Isin")
                .Items.Add("Kaiama")
                .Items.Add("Moro")
                .Items.Add("Offa")
                .Items.Add("Oke-Ero")
                .Items.Add("Oyun")
                .Items.Add("Pategi")
            ElseIf ComboBox2.Text = "LAGOS" Then
                ComboBox3.Items.Clear()
                .Items.Add("Agege")
                .Items.Add("Ajeromi-Ifelodun")
                .Items.Add("Alimosho")
                .Items.Add("Amuwo-Odofin")
                .Items.Add("Apapa")
                .Items.Add("Badagry")
                .Items.Add("Epe")
                .Items.Add("Eti-Osa")
                .Items.Add("Ibeju/Lekki")
                .Items.Add("Ifako-Ijaye")
                .Items.Add("Ikeja")
                .Items.Add("Ikorodu")
                .Items.Add("Kosofe")
                .Items.Add("Lagos Island")
                .Items.Add("Logos Mainland")
                .Items.Add("Mushin")
                .Items.Add("Ojo")
                .Items.Add("Oshodi-Isolo")
                .Items.Add("Shomolu")
                .Items.Add("Surulere")
            ElseIf ComboBox2.Text = "NASSARAWA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Akwanga")
                .Items.Add("Awe")
                .Items.Add("Doma")
                .Items.Add("Karu")
                .Items.Add("Keana")
                .Items.Add("Keffi")
                .Items.Add("Kokona")
                .Items.Add("Lafia")
                .Items.Add("Nasarawa")
                .Items.Add("Nasarawa Eggon")
                .Items.Add("Obi")
                .Items.Add("Toto")
                .Items.Add("Wamba")
            ElseIf ComboBox2.Text = "NIGER" Then
                ComboBox3.Items.Clear()
                .Items.Add("Agaie")
                .Items.Add("Agwara")
                .Items.Add("Bida")
                .Items.Add("Borgu")
                .Items.Add("Bosso")
                .Items.Add("Chanchaga")
                .Items.Add("Edati")
                .Items.Add("Gbako")
                .Items.Add("Gurara")
                .Items.Add("Katcha")
                .Items.Add("Kontagora")
                .Items.Add("Lapai")
                .Items.Add("Lavun")
                .Items.Add("Magama")
                .Items.Add("Mariga")
                .Items.Add("Mashegu")
                .Items.Add("Mokwa")
                .Items.Add("Muya")
                .Items.Add("Pailoro")
                .Items.Add("Rafi")
                .Items.Add("Rijau")
                .Items.Add("Shioro")
                .Items.Add("Suleja")
                .Items.Add("Tafa")
                .Items.Add("Wushishi")
            ElseIf ComboBox2.Text = "OGUN" Then
                ComboBox3.Items.Clear()
                .Items.Add("Abeokuta North")
                .Items.Add("Abeokuta South")
                .Items.Add("Ado-Odo/Ota")
                .Items.Add("Egbado North")
                .Items.Add("Egbado South")
                .Items.Add("Ewekoro")
                .Items.Add("Ifo")
                .Items.Add("Ijebu East")
                .Items.Add("Ijebu North")
                .Items.Add("Ijebu North East")
                .Items.Add("Ijebu Ode")
                .Items.Add("Ikenne")
                .Items.Add("Imeko-Afon")
                .Items.Add("Ipokia")
                .Items.Add("Obafemi- Owode")
                .Items.Add("Ogun Waterside")
                .Items.Add("Odeda")
                .Items.Add("Odogbolu")
                .Items.Add("Remo North")
                .Items.Add("Shagamu")
            ElseIf ComboBox2.Text = "ONDO" Then
                ComboBox3.Items.Clear()
                .Items.Add("Akoko North East")
                .Items.Add("Akoko North West ")
                .Items.Add("Akoko South Akure East")
                .Items.Add("Akoko South West")
                .Items.Add("Akure North")
                .Items.Add("Akure South")
                .Items.Add("Ese-Odo")
                .Items.Add("Idanre")
                .Items.Add("Ifedore")
                .Items.Add("Ilaje")
                .Items.Add("Ile-Oluji")
                .Items.Add("Okeigbo")
                .Items.Add("Irele")
                .Items.Add("Odigbo")
                .Items.Add("Okitipupa")
                .Items.Add("Ondo East")
                .Items.Add("Ondo West")
                .Items.Add("Ose")
                .Items.Add("Owo")
            ElseIf ComboBox2.Text = "OSUN" Then
                ComboBox3.Items.Clear()
                .Items.Add("Aiyedade")
                .Items.Add("Aiyedire")
                .Items.Add("Atakumosa East")
                .Items.Add("Atakumosa West")
                .Items.Add("Boluwaduro")
                .Items.Add("Boripe")
                .Items.Add("Ede North")
                .Items.Add("Ede South")
                .Items.Add("Egbedore")
                .Items.Add("Ejigbo")
                .Items.Add("Ife Central")
                .Items.Add("Ife East")
                .Items.Add("Ife North")
                .Items.Add("Ife South")
                .Items.Add("Ifedayo")
                .Items.Add("Ifelodun")
                .Items.Add("Ila")
                .Items.Add("Ilesha East")
                .Items.Add("Ilesha West")
                .Items.Add("Irepodun")
                .Items.Add("Irewole")
                .Items.Add("Isokan")
                .Items.Add("Iwo")
                .Items.Add("Obokun")
                .Items.Add("Odo-Otin")
                .Items.Add("Ola-Oluwa")
                .Items.Add("Olorunda")
                .Items.Add("Oriade")
                .Items.Add("Orolu")
                .Items.Add("Osogbo")
            ElseIf ComboBox2.Text = "OYO" Then
                ComboBox3.Items.Clear()
                .Items.Add("Afijio")
                .Items.Add("Akinyele")
                .Items.Add("Atiba")
                .Items.Add("Atigbo")
                .Items.Add("Egbeda")
                .Items.Add("Ibadan Central")
                .Items.Add("Ibadan North")
                .Items.Add("Ibadan North West")
                .Items.Add("Ibadan South East")
                .Items.Add("Ibadan South West")
                .Items.Add("Ibarapa Central")
                .Items.Add("Ibarapa East")
                .Items.Add("Ibarapa North")
                .Items.Add("Ido")
                .Items.Add("Irepo")
                .Items.Add("Iseyin")
                .Items.Add("Itesiwaju")
                .Items.Add("Iwajowa")
                .Items.Add("Kajola")
                .Items.Add("Legelu Ogbomosho")
                .Items.Add("Ogbomosho South")
                .Items.Add("Ogo Oluwa")
                .Items.Add("Olorunsogo")
                .Items.Add("Oluyole")
                .Items.Add("Ona-Ara")
                .Items.Add("Orelope")
                .Items.Add("Ori Ire")
                .Items.Add("Oyo East")
                .Items.Add("Oyo west")
                .Items.Add("saki East")
                .Items.Add("sAKI West")
                .Items.Add("Surulere")
            ElseIf ComboBox2.Text = "PLATEAU" Then
                ComboBox3.Items.Clear()
                .Items.Add("Barikin Ladi")
                .Items.Add("Bassa")
                .Items.Add("Bokkos")
                .Items.Add("Jos East")
                .Items.Add("Jos North")
                .Items.Add("Jos South")
                .Items.Add("Kanam")
                .Items.Add("Kanke")
                .Items.Add("Langtang North")
                .Items.Add("Langtang South")
                .Items.Add("Mangu")
                .Items.Add("Mikang")
                .Items.Add("Pankshin")
                .Items.Add("Qua'an")
                .Items.Add("Riyom")
                .Items.Add("Shendam")
                .Items.Add("Wase")
            ElseIf ComboBox2.Text = "RIVERS" Then
                ComboBox3.Items.Clear()
                .Items.Add("Abua/Odual")
                .Items.Add("Ahoada East")
                .Items.Add("Ahoada West")
                .Items.Add("Akuku Toru")
                .Items.Add("Andoni")
                .Items.Add("Asari-Toru")
                .Items.Add("Bonny")
                .Items.Add("Degema")
                .Items.Add("Emohua")
                .Items.Add("Eleme")
                .Items.Add("Etche")
                .Items.Add("Gokana")
                .Items.Add("Ikwerre")
                .Items.Add("Khana")
                .Items.Add("Obia/Akpor")
                .Items.Add("Ogba/Egbema/Ndoni")
                .Items.Add("Ogu/Bolo")
                .Items.Add("Okrika")
                .Items.Add("Omumma")
                .Items.Add("Opobo/Nkoro")
                .Items.Add("Oyigbo")
                .Items.Add("Port-harcourt")
                .Items.Add("Tai")
            ElseIf ComboBox2.Text = "SOKOTO" Then
                ComboBox3.Items.Clear()
                .Items.Add("Binji")
                .Items.Add("Bodinga")
                .Items.Add("Dange-Shnsi")
                .Items.Add("Gada")
                .Items.Add("Goronyo")
                .Items.Add("Gudu")
                .Items.Add("Gawabawa")
                .Items.Add("Ilela")
                .Items.Add("Isa")
                .Items.Add("Kware")
                .Items.Add("Kebbe")
                .Items.Add("Rabah")
                .Items.Add("Sabon birini")
                .Items.Add("Shagari")
                .Items.Add("Silame")
                .Items.Add("Sokoto North")
                .Items.Add("Sokoto South")
                .Items.Add("Tambuwal")
                .Items.Add("Tqngaza")
                .Items.Add("Tureta")
                .Items.Add("Wamako")
                .Items.Add("Wurno")
                .Items.Add("Yabo")
            ElseIf ComboBox2.Text = "TARABA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Ardo-kola")
                .Items.Add("Bali")
                .Items.Add("Donga")
                .Items.Add("Gashaka")
                .Items.Add("Cassol")
                .Items.Add("Ibi")
                .Items.Add("Jalingo")
                .Items.Add("Karin-Lamido")
                .Items.Add("Kurim")
                .Items.Add("Lau")
                .Items.Add("Sardauna")
                .Items.Add("Takum")
                .Items.Add("Ussa")
                .Items.Add("Wukari")
                .Items.Add("Yoro")
                .Items.Add("Zing")
            ElseIf ComboBox2.Text = "YOBE" Then
                ComboBox3.Items.Clear()
                .Items.Add("Bade")
                .Items.Add("Bursari")
                .Items.Add("Damaturu")
                .Items.Add("Fika")
                .Items.Add("Fune")
                .Items.Add("Geidam")
                .Items.Add("Gujba")
                .Items.Add("Gulani")
                .Items.Add("Jakusko")
                .Items.Add("Karasuwa")
                .Items.Add("Karawa")
                .Items.Add("Mechina")
                .Items.Add("Nangere")
                .Items.Add("Nguru Potiskum")
                .Items.Add("Tarmua")
                .Items.Add("Yunusari")
                .Items.Add("Yusufari")
            ElseIf ComboBox2.Text = "ZAMFARA" Then
                ComboBox3.Items.Clear()
                .Items.Add("Anka")
                .Items.Add("Bakura")
                .Items.Add("Birnin Magaji")
                .Items.Add("Bukkuyum")
                .Items.Add("Bungudu")
                .Items.Add("Gummi")
                .Items.Add("Gusau")
                .Items.Add("Kaura")
                .Items.Add("Namoda")
                .Items.Add("Maradun")
                .Items.Add("Maru")
                .Items.Add("Shinkafi")
                .Items.Add("Talata Mafara")
                .Items.Add("Tsafe")
                .Items.Add("Zurmi")
            End If
        End With
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Try
            ' Save the image
            Dim imagePath As String = Path.Combine(Application.StartupPath, "pic", TextBox3.Text & TextBox6.Text & ".jpg")
            PictureBox1.Image.Save(imagePath)

            ' Define SQL command for inserting staff details
            Dim sql As String = "INSERT INTO staff (staffid, Lect, Pnum, mail, sta, lga, homt, addr, clas, cat, leve, adpost, dept, pic, pswd) " &
                            "VALUES (@StaffId, @Lect, @Pnum, @Mail, @Sta, @Lga, @Homt, @Addr, @Clas, @Cat, @Leve, @Adpost, @Dept, @Pic, @Pswd)"

            ' Create a list of parameters for the SQL command
            Dim sqlParams As New List(Of SqlParameter) From {
            New SqlParameter("@StaffId", TextBox11.Text),
            New SqlParameter("@Lect", $"{ComboBox1.Text} {TextBox3.Text} {TextBox4.Text(0)}. {TextBox5.Text(0)}."),
            New SqlParameter("@Pnum", TextBox6.Text),
            New SqlParameter("@Mail", TextBox1.Text),
            New SqlParameter("@Sta", ComboBox2.Text),
            New SqlParameter("@Lga", ComboBox3.Text),
            New SqlParameter("@Homt", TextBox7.Text),
            New SqlParameter("@Addr", TextBox8.Text),
            New SqlParameter("@Clas", ComboBox6.Text),
            New SqlParameter("@Cat", ComboBox5.Text),
            New SqlParameter("@Leve", "NIL"),
            New SqlParameter("@Adpost", TextBox15.Text),
            New SqlParameter("@Dept", ComboBox8.Text),
            New SqlParameter("@Pic", $"{TextBox3.Text}{TextBox6.Text}.jpg"),
            New SqlParameter("@Pswd", TextBox9.Text)
        }

            ' Execute the SQL command
            Using connection As New SqlConnection("YourConnectionStringHere")
                Using command As New SqlCommand(sql, connection)
                    command.Parameters.AddRange(sqlParams.ToArray())
                    connection.Open()
                    command.ExecuteNonQuery()
                End Using
            End Using

            MsgBox("SAVED SUCCESSFULLY", vbInformation, "CA")
        Catch ex As Exception
            MessageBox.Show("An error occurred: " & ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        Form2.Show()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        OpenFileDialog1.ShowDialog()
        PictureBox1.Image = Image.FromFile(OpenFileDialog1.FileName)
        Panel2.Enabled = True
    End Sub


    Private Sub TextBox6_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox6.KeyPress
        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 48 Or Asc(e.KeyChar) > 57 Then
                e.Handled = True
            End If
        End If
    End Sub
    Private Sub TextBox3_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox3.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 65 Or Asc(e.KeyChar) > 122 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox4_TextChanged(sender As Object, e As EventArgs) Handles TextBox4.TextChanged

    End Sub

    Private Sub TextBox4_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox4.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 65 Or Asc(e.KeyChar) > 122 Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs) Handles TextBox5.TextChanged

    End Sub

    Private Sub TextBox5_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TextBox5.KeyPress
        '97 - 122 = Ascii codes for simple letters
        '65 - 90  = Ascii codes for capital letters
        '48 - 57  = Ascii codes for numbers

        If Asc(e.KeyChar) <> 8 Then
            If Asc(e.KeyChar) < 65 Or Asc(e.KeyChar) > 122 Then
                e.Handled = True
            End If
        End If
    End Sub
End Class