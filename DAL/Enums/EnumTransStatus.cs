namespace WebAPIAFFS.DAL.Enums
{
    public enum APIResponseStatus
    {
        Success = 1,
        Error = 2,
        NotFound = 3,
        Created = 4
    }

    public enum UserType
    {
        Department,
        HOD,
        SAO,
        DDO
    }
    public enum UserLevel
    {
        Department,
        HoD,
        RO,
        DO,
        SDO
    }
    public enum EnumTransStatus
    {
        New,
        Reverted,
        Approved,
        DraftSanctioned,
        Sanctioned,
        Deleted
    }

    public enum EnumSanctionType
    {

        Allotment,
        GrantInHead,
        Sanction,
        Withdrawl

    }
    public enum EnumTransactionType
    {
        Release,
        Revoke
    }
    public enum EnumReleaseMapType
    {
        HOD_to_SAO,
        HOD_to_DDO,
        SAO_to_DDO,
        SAO_to_SAO
    }
    public enum EnumRevokeMapType
    {
        SAO_to_HOD = 4,
        DDO_to_HOD,
        SAO_to_SAO,
        DDO_to_SAO
    }

    public enum TokenType
    {
        AccessToken = 1
        //RefresToken = 2
    }

    public enum ClaimType
    {
        UserId = 1,
        //UserType = 2,
        Email = 3,
        //Jti = 4,
        Role = 5,
        TokenType = 6
    }

}
