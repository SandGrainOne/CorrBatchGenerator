﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// 
// This source code was auto-generated by xsd, Version=4.6.1055.0.
// 
namespace Altinn.Batch.Correspondence {
    using System.Xml.Serialization;
    
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    [System.Xml.Serialization.XmlRootAttribute(Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10", IsNullable=false)]
    public partial class Correspondences {
        
        private string systemUserCodeField;
        
        private string shipmentReferenceField;
        
        private string sequenceNoField;
        
        private CorrespondencesCorrespondence[] correspondenceField;
        
        /// <remarks/>
        public string SystemUserCode {
            get {
                return this.systemUserCodeField;
            }
            set {
                this.systemUserCodeField = value;
            }
        }
        
        /// <remarks/>
        public string ShipmentReference {
            get {
                return this.shipmentReferenceField;
            }
            set {
                this.shipmentReferenceField = value;
            }
        }
        
        /// <remarks/>
        public string SequenceNo {
            get {
                return this.sequenceNoField;
            }
            set {
                this.sequenceNoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Correspondence")]
        public CorrespondencesCorrespondence[] Correspondence {
            get {
                return this.correspondenceField;
            }
            set {
                this.correspondenceField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondence {
        
        private string serviceCodeField;
        
        private string serviceEditionField;
        
        private string sendersReferenceField;
        
        private string reporteeField;
        
        private CorrespondencesCorrespondenceContent contentField;
        
        private System.DateTime visibleDateTimeField;
        
        private bool visibleDateTimeFieldSpecified;
        
        private System.DateTime allowSystemDeleteDateTimeField;
        
        private bool allowSystemDeleteDateTimeFieldSpecified;
        
        private System.DateTime dueDateTimeField;
        
        private bool dueDateTimeFieldSpecified;
        
        private string archiveReferenceField;
        
        private CorrespondencesCorrespondenceReplyOption[] replyOptionsField;
        
        private CorrespondencesCorrespondenceNotification[] notificationsField;
        
        private bool allowForwardingField;
        
        private bool allowForwardingFieldSpecified;
        
        private int caseIdField;
        
        private bool caseIdFieldSpecified;
        
        private bool isReservableField;
        
        private bool isReservableFieldSpecified;
        
        private CorrespondencesCorrespondenceSdpOptions sdpOptionsField;
        
        private string onBehalfOfOrgNrField;
        
        /// <remarks/>
        public string ServiceCode {
            get {
                return this.serviceCodeField;
            }
            set {
                this.serviceCodeField = value;
            }
        }
        
        /// <remarks/>
        public string ServiceEdition {
            get {
                return this.serviceEditionField;
            }
            set {
                this.serviceEditionField = value;
            }
        }
        
        /// <remarks/>
        public string SendersReference {
            get {
                return this.sendersReferenceField;
            }
            set {
                this.sendersReferenceField = value;
            }
        }
        
        /// <remarks/>
        public string Reportee {
            get {
                return this.reporteeField;
            }
            set {
                this.reporteeField = value;
            }
        }
        
        /// <remarks/>
        public CorrespondencesCorrespondenceContent Content {
            get {
                return this.contentField;
            }
            set {
                this.contentField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime VisibleDateTime {
            get {
                return this.visibleDateTimeField;
            }
            set {
                this.visibleDateTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool VisibleDateTimeSpecified {
            get {
                return this.visibleDateTimeFieldSpecified;
            }
            set {
                this.visibleDateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime AllowSystemDeleteDateTime {
            get {
                return this.allowSystemDeleteDateTimeField;
            }
            set {
                this.allowSystemDeleteDateTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AllowSystemDeleteDateTimeSpecified {
            get {
                return this.allowSystemDeleteDateTimeFieldSpecified;
            }
            set {
                this.allowSystemDeleteDateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime DueDateTime {
            get {
                return this.dueDateTimeField;
            }
            set {
                this.dueDateTimeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DueDateTimeSpecified {
            get {
                return this.dueDateTimeFieldSpecified;
            }
            set {
                this.dueDateTimeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string ArchiveReference {
            get {
                return this.archiveReferenceField;
            }
            set {
                this.archiveReferenceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReplyOption", IsNullable=false)]
        public CorrespondencesCorrespondenceReplyOption[] ReplyOptions {
            get {
                return this.replyOptionsField;
            }
            set {
                this.replyOptionsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Notification", IsNullable=false)]
        public CorrespondencesCorrespondenceNotification[] Notifications {
            get {
                return this.notificationsField;
            }
            set {
                this.notificationsField = value;
            }
        }
        
        /// <remarks/>
        public bool AllowForwarding {
            get {
                return this.allowForwardingField;
            }
            set {
                this.allowForwardingField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool AllowForwardingSpecified {
            get {
                return this.allowForwardingFieldSpecified;
            }
            set {
                this.allowForwardingFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public int CaseId {
            get {
                return this.caseIdField;
            }
            set {
                this.caseIdField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CaseIdSpecified {
            get {
                return this.caseIdFieldSpecified;
            }
            set {
                this.caseIdFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public bool IsReservable {
            get {
                return this.isReservableField;
            }
            set {
                this.isReservableField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IsReservableSpecified {
            get {
                return this.isReservableFieldSpecified;
            }
            set {
                this.isReservableFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public CorrespondencesCorrespondenceSdpOptions SdpOptions {
            get {
                return this.sdpOptionsField;
            }
            set {
                this.sdpOptionsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(IsNullable=true)]
        public string OnBehalfOfOrgNr {
            get {
                return this.onBehalfOfOrgNrField;
            }
            set {
                this.onBehalfOfOrgNrField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceContent {
        
        private string languageCodeField;
        
        private string messageTitleField;
        
        private string messageSummaryField;
        
        private object messageBodyField;
        
        private CorrespondencesCorrespondenceContentAdd[] customMessageDataField;
        
        private CorrespondencesCorrespondenceContentAttachments attachmentsField;
        
        /// <remarks/>
        public string LanguageCode {
            get {
                return this.languageCodeField;
            }
            set {
                this.languageCodeField = value;
            }
        }
        
        /// <remarks/>
        public string MessageTitle {
            get {
                return this.messageTitleField;
            }
            set {
                this.messageTitleField = value;
            }
        }
        
        /// <remarks/>
        public string MessageSummary {
            get {
                return this.messageSummaryField;
            }
            set {
                this.messageSummaryField = value;
            }
        }
        
        /// <remarks/>
        public object MessageBody {
            get {
                return this.messageBodyField;
            }
            set {
                this.messageBodyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("Add", IsNullable=false)]
        public CorrespondencesCorrespondenceContentAdd[] CustomMessageData {
            get {
                return this.customMessageDataField;
            }
            set {
                this.customMessageDataField = value;
            }
        }
        
        /// <remarks/>
        public CorrespondencesCorrespondenceContentAttachments Attachments {
            get {
                return this.attachmentsField;
            }
            set {
                this.attachmentsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceContentAdd {
        
        private string keyField;
        
        private string valueField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceContentAttachments {
        
        private CorrespondencesCorrespondenceContentAttachmentsBinaryAttachment[] binaryAttachmentsField;
        
        private CorrespondencesCorrespondenceContentAttachmentsXmlAttachment[] xmlAttachmentsField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("BinaryAttachment", IsNullable=false)]
        public CorrespondencesCorrespondenceContentAttachmentsBinaryAttachment[] BinaryAttachments {
            get {
                return this.binaryAttachmentsField;
            }
            set {
                this.binaryAttachmentsField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("XmlAttachment", IsNullable=false)]
        public CorrespondencesCorrespondenceContentAttachmentsXmlAttachment[] XmlAttachments {
            get {
                return this.xmlAttachmentsField;
            }
            set {
                this.xmlAttachmentsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceContentAttachmentsBinaryAttachment {
        
        private string fileNameField;
        
        private string nameField;
        
        private bool encryptedField;
        
        private byte[] dataField;
        
        private string sendersReferenceField;
        
        private string functionTypeField;
        
        private string attachmentTypeField;
        
        private string destinationTypeField;
        
        /// <remarks/>
        public string FileName {
            get {
                return this.fileNameField;
            }
            set {
                this.fileNameField = value;
            }
        }
        
        /// <remarks/>
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        public bool Encrypted {
            get {
                return this.encryptedField;
            }
            set {
                this.encryptedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(DataType="base64Binary")]
        public byte[] Data {
            get {
                return this.dataField;
            }
            set {
                this.dataField = value;
            }
        }
        
        /// <remarks/>
        public string SendersReference {
            get {
                return this.sendersReferenceField;
            }
            set {
                this.sendersReferenceField = value;
            }
        }
        
        /// <remarks/>
        public string FunctionType {
            get {
                return this.functionTypeField;
            }
            set {
                this.functionTypeField = value;
            }
        }
        
        /// <remarks/>
        public string AttachmentType {
            get {
                return this.attachmentTypeField;
            }
            set {
                this.attachmentTypeField = value;
            }
        }
        
        /// <remarks/>
        public string DestinationType {
            get {
                return this.destinationTypeField;
            }
            set {
                this.destinationTypeField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceContentAttachmentsXmlAttachment {
        
        private string sendersReferenceField;
        
        private string dataFormatIDField;
        
        private int dataFormatVersionField;
        
        private string formDataXmlField;
        
        /// <remarks/>
        public string SendersReference {
            get {
                return this.sendersReferenceField;
            }
            set {
                this.sendersReferenceField = value;
            }
        }
        
        /// <remarks/>
        public string DataFormatID {
            get {
                return this.dataFormatIDField;
            }
            set {
                this.dataFormatIDField = value;
            }
        }
        
        /// <remarks/>
        public int DataFormatVersion {
            get {
                return this.dataFormatVersionField;
            }
            set {
                this.dataFormatVersionField = value;
            }
        }
        
        /// <remarks/>
        public string FormDataXml {
            get {
                return this.formDataXmlField;
            }
            set {
                this.formDataXmlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceReplyOption {
        
        private object itemField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ArchiveReference", typeof(string))]
        [System.Xml.Serialization.XmlElementAttribute("Service", typeof(CorrespondencesCorrespondenceReplyOptionService))]
        [System.Xml.Serialization.XmlElementAttribute("Url", typeof(CorrespondencesCorrespondenceReplyOptionUrl))]
        public object Item {
            get {
                return this.itemField;
            }
            set {
                this.itemField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceReplyOptionService {
        
        private string serviceCodeField;
        
        private string serviceEditionField;
        
        /// <remarks/>
        public string ServiceCode {
            get {
                return this.serviceCodeField;
            }
            set {
                this.serviceCodeField = value;
            }
        }
        
        /// <remarks/>
        public string ServiceEdition {
            get {
                return this.serviceEditionField;
            }
            set {
                this.serviceEditionField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceReplyOptionUrl {
        
        private string linkTextField;
        
        private string linkUrlField;
        
        /// <remarks/>
        public string LinkText {
            get {
                return this.linkTextField;
            }
            set {
                this.linkTextField = value;
            }
        }
        
        /// <remarks/>
        public string LinkUrl {
            get {
                return this.linkUrlField;
            }
            set {
                this.linkUrlField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceNotification {
        
        private string fromAdressField;
        
        private System.DateTime shipmentDateTimeField;
        
        private string languageCodeField;
        
        private string notificationTypeField;
        
        private CorrespondencesCorrespondenceNotificationTextToken[] textTokensField;
        
        private CorrespondencesCorrespondenceNotificationReceiverEndPoint[] recieverEndPointsField;
        
        /// <remarks/>
        public string FromAdress {
            get {
                return this.fromAdressField;
            }
            set {
                this.fromAdressField = value;
            }
        }
        
        /// <remarks/>
        public System.DateTime ShipmentDateTime {
            get {
                return this.shipmentDateTimeField;
            }
            set {
                this.shipmentDateTimeField = value;
            }
        }
        
        /// <remarks/>
        public string LanguageCode {
            get {
                return this.languageCodeField;
            }
            set {
                this.languageCodeField = value;
            }
        }
        
        /// <remarks/>
        public string NotificationType {
            get {
                return this.notificationTypeField;
            }
            set {
                this.notificationTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("TextToken", IsNullable=false)]
        public CorrespondencesCorrespondenceNotificationTextToken[] TextTokens {
            get {
                return this.textTokensField;
            }
            set {
                this.textTokensField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("ReceiverEndPoint", IsNullable=false)]
        public CorrespondencesCorrespondenceNotificationReceiverEndPoint[] RecieverEndPoints {
            get {
                return this.recieverEndPointsField;
            }
            set {
                this.recieverEndPointsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceNotificationTextToken {
        
        private int tokenNumField;
        
        private string tokenValueField;
        
        /// <remarks/>
        public int TokenNum {
            get {
                return this.tokenNumField;
            }
            set {
                this.tokenNumField = value;
            }
        }
        
        /// <remarks/>
        public string TokenValue {
            get {
                return this.tokenValueField;
            }
            set {
                this.tokenValueField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceNotificationReceiverEndPoint {
        
        private string transportTypeField;
        
        private string receiverAdressField;
        
        /// <remarks/>
        public string TransportType {
            get {
                return this.transportTypeField;
            }
            set {
                this.transportTypeField = value;
            }
        }
        
        /// <remarks/>
        public string ReceiverAdress {
            get {
                return this.receiverAdressField;
            }
            set {
                this.receiverAdressField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceSdpOptions {
        
        private CorrespondencesCorrespondenceSdpOptionsSdpSetting sdpSettingField;
        
        private bool backupAltinnField;
        
        private bool backupAltinnFieldSpecified;
        
        private string primaryDocumentFileNameField;
        
        private CorrespondencesCorrespondenceSdpOptionsSdpNotifications sdpNotificationsField;
        
        /// <remarks/>
        public CorrespondencesCorrespondenceSdpOptionsSdpSetting SdpSetting {
            get {
                return this.sdpSettingField;
            }
            set {
                this.sdpSettingField = value;
            }
        }
        
        /// <remarks/>
        public bool BackupAltinn {
            get {
                return this.backupAltinnField;
            }
            set {
                this.backupAltinnField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BackupAltinnSpecified {
            get {
                return this.backupAltinnFieldSpecified;
            }
            set {
                this.backupAltinnFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        public string PrimaryDocumentFileName {
            get {
                return this.primaryDocumentFileNameField;
            }
            set {
                this.primaryDocumentFileNameField = value;
            }
        }
        
        /// <remarks/>
        public CorrespondencesCorrespondenceSdpOptionsSdpNotifications SdpNotifications {
            get {
                return this.sdpNotificationsField;
            }
            set {
                this.sdpNotificationsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public enum CorrespondencesCorrespondenceSdpOptionsSdpSetting {
        
        /// <remarks/>
        ForwardOnly,
        
        /// <remarks/>
        CopyAltinn,
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceSdpOptionsSdpNotifications {
        
        private CorrespondencesCorrespondenceSdpOptionsSdpNotificationsEmailNotification emailNotificationField;
        
        private CorrespondencesCorrespondenceSdpOptionsSdpNotificationsSmsNotification smsNotificationField;
        
        /// <remarks/>
        public CorrespondencesCorrespondenceSdpOptionsSdpNotificationsEmailNotification EmailNotification {
            get {
                return this.emailNotificationField;
            }
            set {
                this.emailNotificationField = value;
            }
        }
        
        /// <remarks/>
        public CorrespondencesCorrespondenceSdpOptionsSdpNotificationsSmsNotification SmsNotification {
            get {
                return this.smsNotificationField;
            }
            set {
                this.smsNotificationField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceSdpOptionsSdpNotificationsEmailNotification {
        
        private string notificationTextField;
        
        private string emailAddressField;
        
        private uint[] repetitionsField;
        
        /// <remarks/>
        public string NotificationText {
            get {
                return this.notificationTextField;
            }
            set {
                this.notificationTextField = value;
            }
        }
        
        /// <remarks/>
        public string EmailAddress {
            get {
                return this.emailAddressField;
            }
            set {
                this.emailAddressField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("DaysDelayed", IsNullable=false)]
        public uint[] Repetitions {
            get {
                return this.repetitionsField;
            }
            set {
                this.repetitionsField = value;
            }
        }
    }
    
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "4.6.1055.0")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://schemas.altinn.no/services/intermediary/correspondence/2009/10")]
    public partial class CorrespondencesCorrespondenceSdpOptionsSdpNotificationsSmsNotification {
        
        private string notificationTextField;
        
        private string mobileNumberField;
        
        private uint[] repetitionsField;
        
        /// <remarks/>
        public string NotificationText {
            get {
                return this.notificationTextField;
            }
            set {
                this.notificationTextField = value;
            }
        }
        
        /// <remarks/>
        public string MobileNumber {
            get {
                return this.mobileNumberField;
            }
            set {
                this.mobileNumberField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayItemAttribute("DaysDelayed", IsNullable=false)]
        public uint[] Repetitions {
            get {
                return this.repetitionsField;
            }
            set {
                this.repetitionsField = value;
            }
        }
    }
}
