namespace memento_poc
{
    /**
     *  Essa será nossa classe Caretaker. Caretakers são classes que guardam os mementos, no contexto atual,
     *  a classe History (Caretaker) guardará os Snapshots (Mementos) da classe Editor (Originator) 
     */
    public class History
    {
        private Stack<Snapshot> _snapshots = new Stack<Snapshot>();

        /**
         *  Guardamos a instância do Originator para que possamos restaurar e salvar os estados
         */
        private Editor _editor; 

        public History(Editor editor)
        {
            _editor = editor;
            _snapshots = new Stack<Snapshot>();
        }

        public Editor CurrentEditor() => _editor;

        /**
         *  Como podemos observar, através da implementação desse design pattern, podemos gerenciar os estados da classe editor
         *  em uma classe terceira sem que ela sequer precise acessar ou modificar atributos privados. Ou seja, todo detalhe de implementação
         *  da classe Editor foi abstraído e escondido do mundo exterior 
         */
        public void Save() => _snapshots.Push(_editor.CreateSnapshot());

        public void Restore()
        {
            if (_snapshots.Count == 0)
                return;

            _editor.Restore(_snapshots.Pop());
        }
    }
}
