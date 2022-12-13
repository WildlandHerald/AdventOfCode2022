module Utils

module String =
    let split (delimeter: string) (value: string) = Array.toList (value.Split delimeter)

module List =
    let toPair list =
        match list with
        | [ a; b ] -> (a, b)
        | _ -> invalidArg "list" "List must contain exactly two elements to be converted in pair"
