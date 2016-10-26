using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class Utility : MonoBehaviour{
	private static string[] girlNames = new string[] {"Ana", "Anita", "Amihan", "Amparo", "Vizminda", "Perlita", "Ruping", "Diwa", "Diwata", "Diyosa", "Igme", "Iska", "Laya", "Ligaya", "Liwayway", "Luningning", "Luwalhati", "Luntian", "Luzviminda", "Maningning", "Marikit", "Marilag", "Mayumi", "Perla", "Nenita", "Sampaguita", "Tala", "Sinagtala", "Agapita", "Darna", "Narda", "Hiyas", "Liway", "Maharlika", "Mahalimuyak", "Lyra", "Ligaya", "Mayat", "Mutya", "Perlas", "Rosal", "Yoning", "Didang", "Loleng", "Roseng", "Seniang", "Pitang", "Titang", "Yoling", "Sening", "Yolanda", "Reming", "Rosas", "Rosa", "Marta", "Tibay", "Puring", "Ruding", "Bering", "Bebeng", "Alwina", "Mira", "Tuka", "Muyak", "Mayi", "Amaya", "Dyosa", "Luwalhati", "Alunsina", "Lisaga", "Hiyas", "Andora", "Bangona", "Katana", "Namongan", "Ines", "Binayaan", "Bituin", "Lamitan", "Lingayan", "Hilway", "Mantak", "Kayang", "Bayang", "Apila", "Siray", "Ahak", "Digan", "Tala", "Lakambini", "Kapulong", "Dalisay", "Halina", "Lacaden", "Liwanag", "Lukban", "Abay", "Bagasbas", "Alindog", "Bigayan", "Bulanadi", "Buni", "Agpalo", "Baitan", "Bayanai", "Luna", "Maganda", "Mayari", "Paglinawan", "Ulap", "Sikat", "Himulak", "Mithi", "Anyag", "Sidlak", "Bituon", "Hara", "Linawan", "Awitan", "Visaya", "Halina", "Hilaga", "Ibay", "Lima", "Lindawan", "Lindog", "Liwag", "Dayag", "Silangan", "Maharlika", "Lagunwa", "Inday"};
	private static string[] boyNames = new string[] {"Agapito", "Amado", "Armando", "Arnulfo", "Arturo", "Aurelio", "Avilino", "Ambrosio", "Arwin", "Manolo", "Isagani", "Efren", "Bagwis", "Bayani", "Isko", "Makisig", "Narding", "Ramil", "Agapito", "Alab", "Alad", "Ambo", "Asterio", "Banawag", "Banoy", "Bimbo", "Caloy", "Dakila", "Dalisay", "Cardo", "Magiting", "Migoy", "Pepeng", "Ondoy", "Pedring", "Sendong", "Lando", "Nonoy", "Herming", "Juaning", "Hulyo", "Dakila", "Buhawi", "Aguilos", "Pagaspas", "Hitano", "Dado", "Lakan", "Habagat", "Lawiswis", "Mulagat", "Kuskos", "Aramis", "Bahala", "Alyas", "Amante", "Datu", "Kamandag", "Kaupay", "Kidlat", "Agimat", "Talahib", "Kanakan", "Dali", "Bantugan", "Aliguyon", "Lam-ang", "Apolaki", "Bankaya", "Kaptan", "Ladlaw", "Baltog", "Pantas", "Kasimiro", "Apitong", "Hitano", "Sumarang", "Dayaw", "Lumad", "Bagani", "Angaway", "Bugna", "Kuling", "Banuk", "Agul", "Magtanggol", "Kapuno", "Dasig", "Dayap", "Habalo", "Kalaw", "Katindi", "Laban", "Ligid", "Laing", "Aglipay", "Aguimbag", "Bagsik", "Balagtas", "Balingit", "Bahande", "Baliad", "Lakas", "Malaki", "Kagirim", "Kusug", "Marabi", "Laum", "Dagat", "Dalisay", "Ibabao", "Abayan", "Ambag", "Bakani", "Biag", "Bitagon", "Bocalig", "Butac", "Kadlaon", "Kapili", "Halog", "Hagpis", "Silag", "Katindig", "Banna", "Aliguyon", "Tuwaang", "Agyu"};

	public static string RandomGirlName(){
		return girlNames[Random.Range(0,girlNames.Length)];
	}

	public static string RandomBoyName(){
		return boyNames[Random.Range(0,boyNames.Length)];
	}
}