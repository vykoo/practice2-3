﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using Sukhoviy02.Properties;

namespace Sukhoviy02.Tools
{
    class ObservableItem: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool ChangeAndNotify<T>(ref T field, T value, Expression<Func<T>> memberExpression)
        {
            if (memberExpression == null)
            {
                throw new ArgumentNullException("memberExpression");
            }
            var body = memberExpression.Body as MemberExpression;
            if (body == null)
            {
                throw new ArgumentException("Lambda must return a property.");
            }
            if (EqualityComparer<T>.Default.Equals(field, value))
            {
                return false;
            }

            var vmExpression = body.Expression as ConstantExpression;
            if (vmExpression != null)
            {
                LambdaExpression lambda = Expression.Lambda(vmExpression);
                Delegate vmFunc = lambda.Compile();
                object sender = vmFunc.DynamicInvoke();
                PropertyChanged?.Invoke(sender, new PropertyChangedEventArgs(body.Member.Name));
            }

            field = value;
            return true;
        }

        [NotifyPropertyChangedInvocator]
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
