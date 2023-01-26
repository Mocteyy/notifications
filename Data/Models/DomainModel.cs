namespace Data.Models {
    public interface DomainModel<T> {
        T ToDomainModel();
    }
}