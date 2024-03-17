using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using static ZR.CodingExample.SecureCoding.Services.CustomerDataService;

namespace ZR.CodingExample.SecureCoding.Services;
public interface IDataRepository
{
    void SaveData(CustomerData data);
    CustomerData GetDataById(int id);
    void UpdateData(CustomerData data);
    void DeleteData(int id);
 
}
public class DatabaseRepository : IDataRepository
{
    private readonly DbContext dbContext;

    public DatabaseRepository(DbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void SaveData(CustomerData data)
    {
        dbContext.Set<CustomerData>().Add(data);
        dbContext.SaveChanges();
    }

    public CustomerData GetDataById(int id)
    {
        return dbContext.Set<CustomerData>().Find(id);
    }

    public void UpdateData(CustomerData data)
    {
        dbContext.Entry(data).State = EntityState.Modified;
        dbContext.SaveChanges();
    }

    public void DeleteData(int id)
    {
        var data = GetDataById(id);
        if (data != null)
        {
            dbContext.Set<CustomerData>().Remove(data);
            dbContext.SaveChanges();
        }
    }

 
}

public class CustomerDataService
{
    private readonly IDataRepository dataRepository;

    public CustomerDataService(IDataRepository dataRepository)
    {
        this.dataRepository = dataRepository;
    }
    public class CustomerData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string CreditCardNumber { get; set; }
        

 
        public CustomerData(int id, string name, string email, string creditCardNumber)
        {
            Id = id;
            Name = name;
            Email = email;
            CreditCardNumber = creditCardNumber;
        }
    }

    public void SaveCustomerData(CustomerData data)
    {
       
        bool isValidData = ValidateCustomerData(data);
        if (!isValidData)
        {
            throw new Exception("Invalid customer data.");
        }

       
        data.CreditCardNumber = EncryptionService.Encrypt(data.CreditCardNumber);

        
        dataRepository.SaveData(data);

        
        AuditLogService.LogEvent("Customer data saved");
    }

    private bool ValidateCustomerData(CustomerData data)
    {
        if (data == null)
        {
            return false;  
        }

        if (string.IsNullOrWhiteSpace(data.Name))
        {
            return false; 
        }

        if (string.IsNullOrWhiteSpace(data.Email) || !ZR.CodingExample.SecureCoding.Functions.User.IsValidEmail(data.Email))
        {
            return false;  
        }

        if (string.IsNullOrWhiteSpace(data.CreditCardNumber) || !IsValidCreditCardNumber(data.CreditCardNumber))
        {
            return false;  
        }

        

        return true; 
    }



    private bool IsValidCreditCardNumber(string creditCardNumber)
    {
        
        string cleanedNumber = Regex.Replace(creditCardNumber, @"[^0-9]", "");

        
        if (!Regex.IsMatch(cleanedNumber, @"^\d{13,19}$"))
        {
            return false;  
        }

       
        int sum = 0;
        bool isAlternateDigit = false;

        for (int i = cleanedNumber.Length - 1; i >= 0; i--)
        {
            int digit = int.Parse(cleanedNumber[i].ToString());

            if (isAlternateDigit)
            {
                digit *= 2;
                if (digit > 9)
                {
                    digit = digit - 9;
                }
            }

            sum += digit;
            isAlternateDigit = !isAlternateDigit;
        }

        return sum % 10 == 0; 
    }



    public static class EncryptionService
    {
        private static readonly string EncryptionKey = "YourEncryptionKey";  
        public static string Encrypt(string data)
        {
            byte[] clearBytes = Encoding.Unicode.GetBytes(data);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });

                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(clearBytes, 0, clearBytes.Length);
                        cryptoStream.Close();
                    }
                    return Convert.ToBase64String(memoryStream.ToArray());
                }
            }
        }
    }

    public static class AuditLogService
    {
        public static void LogEvent(string message)
        {
           
            Console.WriteLine($"Event logged: {message}");  
        }
    }

}

