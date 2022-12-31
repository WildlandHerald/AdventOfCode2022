module Utils

module String =
    let split (delimiter: string) (s: string) = Array.toList (s.Split delimiter)

    let halves (s: string) =
        let halfLength = String.length s / 2
        s[halfLength..], s[..halfLength - 1]

    let toSet (s: string) = s |> Seq.toList |> Set.ofList

module Tuple2 =
    let map (f: 'a -> 'b) (a: 'a, b: 'a) = f a, f b
    let map2 (f: 'a -> 'b -> 'c) ((a, b): 'a * 'b) = f a b

module Tuple3 =
    let map (f: 'a -> 'b) (a: 'a, b: 'a, c: 'a) = f a, f b, f c

module List =
    let toPair list =
        match list with
        | [ a; b ] -> (a, b)
        | _ -> invalidArg "list" "List must contain exactly two elements to be converted in pair"
