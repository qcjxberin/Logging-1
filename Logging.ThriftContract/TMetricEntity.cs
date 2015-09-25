/**
 * Autogenerated by Thrift Compiler (0.9.2)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace Logging.ThriftContract
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class TMetricEntity : TBase
  {
    private string _Name;
    private double _Value;
    private long _Time;
    private Dictionary<string, string> _Tags;

    public string Name
    {
      get
      {
        return _Name;
      }
      set
      {
        __isset.Name = true;
        this._Name = value;
      }
    }

    public double Value
    {
      get
      {
        return _Value;
      }
      set
      {
        __isset.@Value = true;
        this._Value = value;
      }
    }

    public long Time
    {
      get
      {
        return _Time;
      }
      set
      {
        __isset.Time = true;
        this._Time = value;
      }
    }

    public Dictionary<string, string> Tags
    {
      get
      {
        return _Tags;
      }
      set
      {
        __isset.Tags = true;
        this._Tags = value;
      }
    }


    public Isset __isset;
    #if !SILVERLIGHT
    [Serializable]
    #endif
    public struct Isset {
      public bool Name;
      public bool @Value;
      public bool Time;
      public bool Tags;
    }

    public TMetricEntity() {
    }

    public void Read (TProtocol iprot)
    {
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.String) {
              Name = iprot.ReadString();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.Double) {
              Value = iprot.ReadDouble();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 3:
            if (field.Type == TType.I64) {
              Time = iprot.ReadI64();
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 4:
            if (field.Type == TType.Map) {
              {
                Tags = new Dictionary<string, string>();
                TMap _map5 = iprot.ReadMapBegin();
                for( int _i6 = 0; _i6 < _map5.Count; ++_i6)
                {
                  string _key7;
                  string _val8;
                  _key7 = iprot.ReadString();
                  _val8 = iprot.ReadString();
                  Tags[_key7] = _val8;
                }
                iprot.ReadMapEnd();
              }
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("TMetricEntity");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      if (Name != null && __isset.Name) {
        field.Name = "Name";
        field.Type = TType.String;
        field.ID = 1;
        oprot.WriteFieldBegin(field);
        oprot.WriteString(Name);
        oprot.WriteFieldEnd();
      }
      if (__isset.@Value) {
        field.Name = "Value";
        field.Type = TType.Double;
        field.ID = 2;
        oprot.WriteFieldBegin(field);
        oprot.WriteDouble(Value);
        oprot.WriteFieldEnd();
      }
      if (__isset.Time) {
        field.Name = "Time";
        field.Type = TType.I64;
        field.ID = 3;
        oprot.WriteFieldBegin(field);
        oprot.WriteI64(Time);
        oprot.WriteFieldEnd();
      }
      if (Tags != null && __isset.Tags) {
        field.Name = "Tags";
        field.Type = TType.Map;
        field.ID = 4;
        oprot.WriteFieldBegin(field);
        {
          oprot.WriteMapBegin(new TMap(TType.String, TType.String, Tags.Count));
          foreach (string _iter9 in Tags.Keys)
          {
            oprot.WriteString(_iter9);
            oprot.WriteString(Tags[_iter9]);
          }
          oprot.WriteMapEnd();
        }
        oprot.WriteFieldEnd();
      }
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder __sb = new StringBuilder("TMetricEntity(");
      bool __first = true;
      if (Name != null && __isset.Name) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Name: ");
        __sb.Append(Name);
      }
      if (__isset.@Value) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Value: ");
        __sb.Append(Value);
      }
      if (__isset.Time) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Time: ");
        __sb.Append(Time);
      }
      if (Tags != null && __isset.Tags) {
        if(!__first) { __sb.Append(", "); }
        __first = false;
        __sb.Append("Tags: ");
        __sb.Append(Tags);
      }
      __sb.Append(")");
      return __sb.ToString();
    }

  }

}