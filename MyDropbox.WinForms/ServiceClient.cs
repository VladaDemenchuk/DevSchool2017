using MyDropbox.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;

namespace MyDropbox.WinForms
{
    public class ServiceClient
    {
        private readonly HttpClient _client = new HttpClient();

        public ServiceClient(string connectionString)
        {
            _client.BaseAddress = new Uri(connectionString);
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public File[] GetUserFiles(Guid currentUserId)
        {
            var response = _client.GetAsync($"users/{currentUserId}/files").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<File[]>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }


        public Comment[] GetFileComments(Guid id)
        {
            var response = _client.GetAsync($"files/{id}/comments").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Comment[]>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public Guid CreateUser(User user)
        {
            var response = _client.PostAsJsonAsync("users", user).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<User>().Result;
                return result.Id;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public Guid CreateFile(File file)
        {
            var response = _client.PostAsJsonAsync("files", file).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<File>().Result;
                return result.Id;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public void UploadFileContent(Guid fileId, byte[] content)
        {
            using (var byteArrayContent = new ByteArrayContent(content))
            {
                var response = _client.PutAsync($"files/{fileId}/content", byteArrayContent).Result;
                if (!response.IsSuccessStatusCode)
                    throw new ServiceException("Error: {0}", response.StatusCode);
            }
        }

        public void DeleteFile(Guid fileId)
        {
            var response = _client.DeleteAsync($"files/{fileId}").Result;
            if (!response.IsSuccessStatusCode)
                throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public byte[] DownloadFile(Guid fileId)
        {
            var response = _client.GetAsync($"files/{fileId}/content").Result;
            if (response.IsSuccessStatusCode)
                return response.Content.ReadAsAsync<byte[]>().Result;
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public User GetUser(Guid currentUserId)
        {
            var response = _client.GetAsync($"users/{currentUserId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<User>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public User GetUser(string email)
        {
            var response = _client.GetAsync($"users/email/{email}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<User>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public Comment CreateComment(Comment comment)
        {
            var response = _client.PostAsJsonAsync("comments", comment).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Comment>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }


        public File GetFile(Guid fileId)
        {
            var response = _client.GetAsync($"files/{fileId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<File>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public Guid GetComment(Guid commentId)
        {
            var response = _client.GetAsync($"comments/{commentId}").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Comment>().Result;
                return result.Id;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public void DeleteComment(Guid commentId)
        {
            var response = _client.DeleteAsync($"comments/{commentId}").Result;
            if (!response.IsSuccessStatusCode)
                throw new ServiceException("Error: {0}", response.StatusCode);
        }

        public Share CreateShare(Share share)
        {
            var response = _client.PostAsJsonAsync("shares", share).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Share>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }


        public File[] GetUserAllowedFiles(Guid id)
        {
            var response = _client.GetAsync($"users/{id}/sharings").Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<File[]>().Result;
                return result;
            }
            throw new ServiceException("Error: {0}", response.StatusCode);
        }

    }
}
