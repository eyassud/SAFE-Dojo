#r "nuget: FSharp.Data"


open FSharp.Data

type OpenMeteoCurrentWeather =
        JsonProvider<"https://api.open-meteo.com/v1/forecast?latitude=51.5074&longitude=-0.083628&current_weather=true">


// type Simple = JsonProvider<""" { "name":"John", "age":94 } """>
// let simple = Simple.Parse(""" { "name":"Tomas", "age":4 } """)
// simple.Age
// simple.Name

let getWeatherForPosition (lat,long) =
        async {

            let! weatherInfo =
                (lat, long)
                ||> sprintf "https://api.open-meteo.com/v1/forecast?latitude=%f&longitude=%f&current_weather=true"
                |> OpenMeteoCurrentWeather.AsyncLoad

            System.Console.WriteLine(weatherInfo.CurrentWeather)
            return weatherInfo.CurrentWeather
        }
async {
    System.Console.WriteLine("..........0")
    let! weather =
            (50.0, -0.08)
            |> getWeatherForPosition
    System.Console.WriteLine(weather.Temperature)
    System.Console.WriteLine("..........")

}
