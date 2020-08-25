using System.Data;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace ItiWfcSelfHosted
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IService1
    {

        [OperationContract]
        BranchData getBranchsData();

        [OperationContract]
        StudentData getStudentsData();

        [OperationContract]
        InstructorData getInstructorsData();
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class BranchData
    {

        [DataMember]
        public DataTable branchsTable
        {
            get;
            set;
        }


        [DataMember]
        public DataTable configTable
        {
            get;
            set;
        }

        [DataMember]
        public DataTable configKeysTable
        {
            get;
            set;
        }

    }

    [DataContract]

    public class StudentData
    {

        [DataMember]
        public DataTable studentsTable
        {
            get;
            set;
        }


        [DataMember]
        public DataTable configTable
        {
            get;
            set;
        }

        [DataMember]
        public DataTable configKeysTable
        {
            get;
            set;
        }

    }

    [DataContract]
    public class InstructorData
    {

        [DataMember]
        public DataTable InstructorsTable
        {
            get;
            set;
        }


        [DataMember]
        public DataTable configTable
        {
            get;
            set;
        }

        [DataMember]
        public DataTable configKeysTable
        {
            get;
            set;
        }

    }

}