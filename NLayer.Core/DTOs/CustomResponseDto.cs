﻿using System.Text.Json.Serialization;

namespace NLayer.Core.DTOs
{
    public class CustomResponseDto<T>
    {
        public T Data { get; set; }
        [JsonIgnore]
        public int StatusCode { get; set; }
        public List<String> Errors { get; set; }

        //static factory method design pattern
        public static CustomResponseDto<T> Success(int statusCode, T data)//create durumu olarak dusunulebilir
        {
            return new CustomResponseDto<T> { Data = data, StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Success(int statusCode) //update ve delete durumunda data donmeye gerek yok
        {
            return new CustomResponseDto<T> { StatusCode = statusCode };
        }

        public static CustomResponseDto<T> Fail(int statusCode, List<string> errors) //birden cok error olmasi durumu
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = errors };
        }

        public static CustomResponseDto<T> Fail(int statusCode, String error) // tek error olmasi durumu
        {
            return new CustomResponseDto<T> { StatusCode = statusCode, Errors = new List<String> { error } };
        }
    }
}
