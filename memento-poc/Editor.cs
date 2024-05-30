namespace memento_poc
{
    /**
     *  Esse é o 'Memento', nesse caso, chamado de Snapshot por ser mais condizente com o contexto de um app de editor de texto.
     *  Poderia também implementar uma interface 'IMemento'
     */
    public class Snapshot
    {
        private string _text;
        private DateTime _created;

        public Snapshot(string text)
        {
            _text = text;
            _created = DateTime.Now;
        }

        public string GetText()
        {
            return _text;
        }

        public DateTime GetDate()
        {
            return _created;
        }
    }

    /**
     *  Nesse contexto de um app de edição de texto, essa seria nossa classe 'Originator', a qual os mementos vão receber
     *  seus estados anteriores.
     */
    public class Editor
    {
        private string _name;
        private string _text;

        public Editor(string name) 
        {
            _name = name;
        }

        public string Name() => _name;

        public void SetText(string text)
        {
            _text = text;   
        }

        public void Display()
        {
            Console.WriteLine($"Editor {_name}:\n{_text}");
        }

        /**
         *  Nós criamos o memento dessa classe dentro dela mesma pois assim garantimos a integridade e encapsulamento dos dados,
         *  escondendo os detalhes de implementação das classes Caretakers, responsáveis por guardar os mementos.
         *  Dessa forma, somente a classe Originator (Editor) vai saber como restaurar seu estado usando seu memento.
         *  Caso não fosse assim, todas as classes que utilizassem e criassem os Snapshots estariam dependentes das possíveis mudanças
         *  na estrutura da classe Editor e Snapshot, além de que poderiam ver todos os atributos privados, ferindo a integridade dos dados.
         */
        public Snapshot CreateSnapshot() => new Snapshot(_text);

        public void Restore(Snapshot snapshot) => _text = snapshot.GetText();
    }
}
