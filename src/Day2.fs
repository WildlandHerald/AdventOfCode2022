module Day2

open Utils
open System.IO

let data = File.ReadAllText("inputs/day2.txt")

type Move =
    | Rock
    | Paper
    | Scissors

let scoreMove =
    function
    | Rock -> 1
    | Paper -> 2
    | Scissors -> 3

let parseMove choice =
    match choice with
    | "A"
    | "X" -> Rock
    | "B"
    | "Y" -> Paper
    | "C"
    | "Z" -> Scissors
    | _ -> invalidArg "choice" "Invalid letter"

let scoreOutcome moves =
    match moves with
    | Scissors, Rock -> 6
    | Rock, Paper -> 6
    | Paper, Scissors -> 6
    | a, b when a = b -> 3
    | _ -> 0

let chooseMove choice =
    match choice with
    | Rock, "X" -> Scissors
    | Rock, "Y" -> Rock
    | Rock, "Z" -> Paper
    | Paper, "X" -> Rock
    | Paper, "Y" -> Paper
    | Paper, "Z" -> Scissors
    | Scissors, "X" -> Paper
    | Scissors, "Y" -> Scissors
    | Scissors, "Z" -> Rock
    | _ -> invalidArg "choice" "Invalid letter"

let scoreRound codes =
    let opponentsMove = fst codes |> parseMove
    let myMove = chooseMove (opponentsMove, (snd codes))

    scoreMove myMove + scoreOutcome (opponentsMove, myMove)

let result =
    data
    |> String.split ("\n")
    |> List.map (String.split (" ") >> List.toPair >> scoreRound)
    |> List.sum

printfn "%A" result
