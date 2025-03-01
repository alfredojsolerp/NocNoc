export class DateUtils {
    private constructor() { }

    public static formatDateForBackend(date: Date): string {
        if (date === undefined) {
            return '';
        }

        const year = date.getFullYear();
        const month = (date.getMonth() + 1).toString().padStart(2, '0');
        const day = date.getDate().toString().padStart(2, '0');
        return `${year}-${month}-${day}`;
    }
}