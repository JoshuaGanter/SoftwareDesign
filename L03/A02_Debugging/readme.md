# Protokoll zur Debugging-Aufgabe

Zu 1): Die Datenstruktur `Person` ist rekursiv, jedes Objekt vom Typ `Person` referenziert seine/ihre Mutter und Vater, zwei weitere Objekte vom Typ `Person`. Das geschieht (in diesem Fall) bis zu einer Rekursionstiefe von 3, sodass 4 Generationen vorhanden sind.

Zu 2): `root` ist die Person "Willi Cambridge", seine `Mom` und `Dad` sind auch jeweils Personen, die wiederum auch ihre Mutter und Vater referenzieren.

Zu 3): Um nicht direkt "Willi" zurückzubekommen kann die Bedingung in [Zeile 22](FamilyTree.cs#L22) beispielsweise zu
```
if (person.LastName != "Cambridge")
```
geändert werden. Dann würde "Willi"s Mutter, "Diana" zurückgegeben, da die Bedingung für "Willi" nicht wahr ist und im Stammbaum eine Generation nach oben gesprungen wird. Da der Stammbaum zuerst auf mütterlicher Seite geprüft wird, wird "Diana" zurückgegeben, da die Bedingung auf sie zutrifft.

Man kann auch expilizit nach einem bestimmten Namen suchen, beispielsweise mit:
```
if (person.LastName == "York")
```
Was "Schorsch-Albert" zurückgeben würde.
Sucht man hier nach einem Namen (oder nach einer anderen Bedingung, die für keine Person im Stammbaum wahr ist), dann wird eine `NullReferenceException` geworfen. Das passiert, weil die letzten Personen des Stammbaums keine Mutter bzw. keinen Vater mehr besitzen, diese Eigenschaften also `null` sind. In [Zeile 22](FamilyTree.cs#L22) wird dann versucht mit (beispielsweise) `person.LastName` auf die nicht existente Eigenschaft `LastName` von `null` zuzugreifen, was mit einer `NullReferenceException` fehlschlägt.

Zu 4): Siehe in [FamilyTree.cs](FamilyTree.cs).