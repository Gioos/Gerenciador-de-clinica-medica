namespace GerenciadorDeClinica.Core.Entities
{
    public abstract class BaseEntity
    {
        protected BaseEntity()
        {
            CriadoEm = DateTime.Now;
            IsDeleted = false;
        }

        public int Id { get; private set; }
        public DateTime CriadoEm { get; private set; }
        public bool IsDeleted { get; private set; }

        public void SetAsDelete()
        {
            IsDeleted = true;
        }
    }
}
