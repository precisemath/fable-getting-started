module App

open Fable.React
open Fable.React.Props

type Model =
    {
        Count: int
    }

 type Msg=
    | Increment
    | Decrement
    | IncrementBy of int
    | Reset

let init () = 
    {Count = 42}

let update msg model : Model =
    match msg with
    | Increment -> {model with Count = model.Count + 1}
    | Decrement -> {model with Count = model.Count - 1}
    | IncrementBy step -> {model with Count = model.Count + step}
    | Reset -> init()

let view model dispatch = 
    div [] 
        [ 
            button [ OnClick ( fun _ -> dispatch Decrement ) ] [ str "-" ]
            h1 [] [ ofInt model.Count ]
            button [ OnClick ( fun _ -> dispatch Increment ) ] [ str "+" ]
            button [ OnClick ( fun _ -> dispatch (IncrementBy 5) ) ] [ str "+5" ]
            button [ OnClick ( fun _ -> dispatch (Reset) ) ] [ str "Reset" ]
            ul [] [ for i in 1..5 -> li [] [ofInt i]]
        ]

open Elmish
open Elmish.React

Program.mkSimple init update view 
|> Program.withReactSynchronous "app"
|> Program.run