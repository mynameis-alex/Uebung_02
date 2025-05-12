# Übung 2

## Aufgabe 2c

Zur Realisierung der Drehung wurde der Spatz als Kind-Element einer Sphäre angeordnet.
Die Rotationsgeschwindigkeit ist jedoch weiterhin über den Spatz steuerbar.
Wählen sie dafür zuerst die Sphäre und anschließend den Spatz aus.

Gleiches gilt für Aufgabe 2d.



## Aufgabe 2f

Die Bäume wachsen mit einer zufälligen Geschwindigkeit und bis zu einer zufälligene maximalen Größe.
Falls das Wachstum zu schnell sein sollte, kann dies notfalls über das Skript angepasst werden.
Dies ist in der `Start()`-Methode des `Forest-Controller`s möglich.

Der Wald kann beliebig um Bäume erweitert werden.
Wichtig hierbei ist jedoch, dass sie hierarchisch dem `Forest` untergeordnet sind.

Sollte kein Baum mehr aktiv sein (alle haben ihre zufällige Maximalhöhe erreicht) fliegt der Vogel auf der Stelle.


## Aufgabe 2h

Die APK-Datei finden Sie im `Build`-Ordner.

Sie können sich mithilfe der üblichen Tasten fortbewegen.

In Ihrer linken Hand befindet sich der Zeigestrahl, welcher eine Länge von fünf Metern hat.
Um einen Baum auszuwählen, sodass der Vogel dorthin fliegt, zeigen Sie auf einen Baum.
Beachten Sie, dass Sie dafür nahe genug an dem Baum sein müssen aufgrund der begrenzten Länge des Strahls.

Das Wachstum der Bäume wurde für diese Aufgabe deaktiviert, damit der Nutzer genug Zeit, mehrere Bäume auszuwählen.