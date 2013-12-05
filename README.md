# WPF: attached properties as an alternative to code behind

The goal of this project is to show how you can create an attached property where would normally use code behind.

As an example, this project contains a `TextBox` which only allows hexadecimal characters.

You would normally implement this by listening the event  `PreviewTextInput` in code behind. In this project, I used an attached properties to do it.

Why is this a big deal ? Simply because you can apply attached properties to any control through styles.

See http://blog.benoitblanchon.fr/attached-properties-vs-code-behind/