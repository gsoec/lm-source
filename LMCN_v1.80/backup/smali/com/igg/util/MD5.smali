.class public Lcom/igg/util/MD5;
.super Ljava/lang/Object;
.source "MD5.java"


# static fields
.field static final PADDING:[B

.field static final S11:I = 0x7

.field static final S12:I = 0xc

.field static final S13:I = 0x11

.field static final S14:I = 0x16

.field static final S21:I = 0x5

.field static final S22:I = 0x9

.field static final S23:I = 0xe

.field static final S24:I = 0x14

.field static final S31:I = 0x4

.field static final S32:I = 0xb

.field static final S33:I = 0x10

.field static final S34:I = 0x17

.field static final S41:I = 0x6

.field static final S42:I = 0xa

.field static final S43:I = 0xf

.field static final S44:I = 0x15


# instance fields
.field private buffer:[B

.field private count:[J

.field private digest:[B

.field public digestHexStr:Ljava/lang/String;

.field private state:[J


# direct methods
.method static constructor <clinit>()V
    .locals 1

    .prologue
    .line 248
    const/16 v0, 0x40

    new-array v0, v0, [B

    fill-array-data v0, :array_0

    sput-object v0, Lcom/igg/util/MD5;->PADDING:[B

    return-void

    :array_0
    .array-data 1
        -0x80t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
        0x0t
    .end array-data
.end method

.method public constructor <init>()V
    .locals 1

    .prologue
    .line 21
    invoke-direct {p0}, Ljava/lang/Object;-><init>()V

    .line 22
    const/4 v0, 0x4

    new-array v0, v0, [J

    iput-object v0, p0, Lcom/igg/util/MD5;->state:[J

    .line 23
    const/4 v0, 0x2

    new-array v0, v0, [J

    iput-object v0, p0, Lcom/igg/util/MD5;->count:[J

    .line 24
    const/16 v0, 0x40

    new-array v0, v0, [B

    iput-object v0, p0, Lcom/igg/util/MD5;->buffer:[B

    .line 25
    const/16 v0, 0x10

    new-array v0, v0, [B

    iput-object v0, p0, Lcom/igg/util/MD5;->digest:[B

    .line 26
    invoke-direct {p0}, Lcom/igg/util/MD5;->md5Init()V

    .line 27
    return-void
.end method

.method private Decode([J[BI)V
    .locals 7
    .param p1, "al"    # [J
    .param p2, "abyte0"    # [B
    .param p3, "i"    # I

    .prologue
    .line 210
    const/4 v0, 0x0

    .line 211
    .local v0, "j":I
    const/4 v1, 0x0

    .local v1, "k":I
    :goto_0
    if-ge v1, p3, :cond_0

    .line 212
    aget-byte v2, p2, v1

    invoke-static {v2}, Lcom/igg/util/MD5;->b2iu(B)J

    move-result-wide v2

    add-int/lit8 v4, v1, 0x1

    aget-byte v4, p2, v4

    invoke-static {v4}, Lcom/igg/util/MD5;->b2iu(B)J

    move-result-wide v4

    const/16 v6, 0x8

    shl-long/2addr v4, v6

    or-long/2addr v2, v4

    add-int/lit8 v4, v1, 0x2

    aget-byte v4, p2, v4

    .line 213
    invoke-static {v4}, Lcom/igg/util/MD5;->b2iu(B)J

    move-result-wide v4

    const/16 v6, 0x10

    shl-long/2addr v4, v6

    or-long/2addr v2, v4

    add-int/lit8 v4, v1, 0x3

    aget-byte v4, p2, v4

    invoke-static {v4}, Lcom/igg/util/MD5;->b2iu(B)J

    move-result-wide v4

    const/16 v6, 0x18

    shl-long/2addr v4, v6

    or-long/2addr v2, v4

    aput-wide v2, p1, v0

    .line 214
    add-int/lit8 v0, v0, 0x1

    .line 211
    add-int/lit8 v1, v1, 0x4

    goto :goto_0

    .line 216
    :cond_0
    return-void
.end method

.method private Encode([B[JI)V
    .locals 8
    .param p1, "abyte0"    # [B
    .param p2, "al"    # [J
    .param p3, "i"    # I

    .prologue
    const-wide/16 v6, 0xff

    .line 199
    const/4 v0, 0x0

    .line 200
    .local v0, "j":I
    const/4 v1, 0x0

    .local v1, "k":I
    :goto_0
    if-ge v1, p3, :cond_0

    .line 201
    aget-wide v2, p2, v0

    and-long/2addr v2, v6

    long-to-int v2, v2

    int-to-byte v2, v2

    aput-byte v2, p1, v1

    .line 202
    add-int/lit8 v2, v1, 0x1

    aget-wide v4, p2, v0

    const/16 v3, 0x8

    ushr-long/2addr v4, v3

    and-long/2addr v4, v6

    long-to-int v3, v4

    int-to-byte v3, v3

    aput-byte v3, p1, v2

    .line 203
    add-int/lit8 v2, v1, 0x2

    aget-wide v4, p2, v0

    const/16 v3, 0x10

    ushr-long/2addr v4, v3

    and-long/2addr v4, v6

    long-to-int v3, v4

    int-to-byte v3, v3

    aput-byte v3, p1, v2

    .line 204
    add-int/lit8 v2, v1, 0x3

    aget-wide v4, p2, v0

    const/16 v3, 0x18

    ushr-long/2addr v4, v3

    and-long/2addr v4, v6

    long-to-int v3, v4

    int-to-byte v3, v3

    aput-byte v3, p1, v2

    .line 205
    add-int/lit8 v0, v0, 0x1

    .line 200
    add-int/lit8 v1, v1, 0x4

    goto :goto_0

    .line 207
    :cond_0
    return-void
.end method

.method private F(JJJ)J
    .locals 5
    .param p1, "l"    # J
    .param p3, "l1"    # J
    .param p5, "l2"    # J

    .prologue
    .line 39
    and-long v0, p1, p3

    const-wide/16 v2, -0x1

    xor-long/2addr v2, p1

    and-long/2addr v2, p5

    or-long/2addr v0, v2

    return-wide v0
.end method

.method private FF(JJJJJJJ)J
    .locals 11
    .param p1, "l"    # J
    .param p3, "l1"    # J
    .param p5, "l2"    # J
    .param p7, "l3"    # J
    .param p9, "l4"    # J
    .param p11, "l5"    # J
    .param p13, "l6"    # J

    .prologue
    .line 55
    move-object v3, p0

    move-wide v4, p3

    move-wide/from16 v6, p5

    move-wide/from16 v8, p7

    invoke-direct/range {v3 .. v9}, Lcom/igg/util/MD5;->F(JJJ)J

    move-result-wide v2

    add-long v2, v2, p9

    add-long v2, v2, p13

    add-long/2addr p1, v2

    .line 56
    long-to-int v2, p1

    move-wide/from16 v0, p11

    long-to-int v3, v0

    shl-int/2addr v2, v3

    long-to-int v3, p1

    const-wide/16 v4, 0x20

    sub-long v4, v4, p11

    long-to-int v4, v4

    ushr-int/2addr v3, v4

    or-int/2addr v2, v3

    int-to-long p1, v2

    .line 57
    add-long/2addr p1, p3

    .line 58
    return-wide p1
.end method

.method private G(JJJ)J
    .locals 5
    .param p1, "l"    # J
    .param p3, "l1"    # J
    .param p5, "l2"    # J

    .prologue
    .line 43
    and-long v0, p1, p5

    const-wide/16 v2, -0x1

    xor-long/2addr v2, p5

    and-long/2addr v2, p3

    or-long/2addr v0, v2

    return-wide v0
.end method

.method private GG(JJJJJJJ)J
    .locals 11
    .param p1, "l"    # J
    .param p3, "l1"    # J
    .param p5, "l2"    # J
    .param p7, "l3"    # J
    .param p9, "l4"    # J
    .param p11, "l5"    # J
    .param p13, "l6"    # J

    .prologue
    .line 62
    move-object v3, p0

    move-wide v4, p3

    move-wide/from16 v6, p5

    move-wide/from16 v8, p7

    invoke-direct/range {v3 .. v9}, Lcom/igg/util/MD5;->G(JJJ)J

    move-result-wide v2

    add-long v2, v2, p9

    add-long v2, v2, p13

    add-long/2addr p1, v2

    .line 63
    long-to-int v2, p1

    move-wide/from16 v0, p11

    long-to-int v3, v0

    shl-int/2addr v2, v3

    long-to-int v3, p1

    const-wide/16 v4, 0x20

    sub-long v4, v4, p11

    long-to-int v4, v4

    ushr-int/2addr v3, v4

    or-int/2addr v2, v3

    int-to-long p1, v2

    .line 64
    add-long/2addr p1, p3

    .line 65
    return-wide p1
.end method

.method private H(JJJ)J
    .locals 3
    .param p1, "l"    # J
    .param p3, "l1"    # J
    .param p5, "l2"    # J

    .prologue
    .line 47
    xor-long v0, p1, p3

    xor-long/2addr v0, p5

    return-wide v0
.end method

.method private HH(JJJJJJJ)J
    .locals 11
    .param p1, "l"    # J
    .param p3, "l1"    # J
    .param p5, "l2"    # J
    .param p7, "l3"    # J
    .param p9, "l4"    # J
    .param p11, "l5"    # J
    .param p13, "l6"    # J

    .prologue
    .line 69
    move-object v3, p0

    move-wide v4, p3

    move-wide/from16 v6, p5

    move-wide/from16 v8, p7

    invoke-direct/range {v3 .. v9}, Lcom/igg/util/MD5;->H(JJJ)J

    move-result-wide v2

    add-long v2, v2, p9

    add-long v2, v2, p13

    add-long/2addr p1, v2

    .line 70
    long-to-int v2, p1

    move-wide/from16 v0, p11

    long-to-int v3, v0

    shl-int/2addr v2, v3

    long-to-int v3, p1

    const-wide/16 v4, 0x20

    sub-long v4, v4, p11

    long-to-int v4, v4

    ushr-int/2addr v3, v4

    or-int/2addr v2, v3

    int-to-long p1, v2

    .line 71
    add-long/2addr p1, p3

    .line 72
    return-wide p1
.end method

.method private I(JJJ)J
    .locals 3
    .param p1, "l"    # J
    .param p3, "l1"    # J
    .param p5, "l2"    # J

    .prologue
    .line 51
    const-wide/16 v0, -0x1

    xor-long/2addr v0, p5

    or-long/2addr v0, p1

    xor-long/2addr v0, p3

    return-wide v0
.end method

.method private II(JJJJJJJ)J
    .locals 11
    .param p1, "l"    # J
    .param p3, "l1"    # J
    .param p5, "l2"    # J
    .param p7, "l3"    # J
    .param p9, "l4"    # J
    .param p11, "l5"    # J
    .param p13, "l6"    # J

    .prologue
    .line 76
    move-object v3, p0

    move-wide v4, p3

    move-wide/from16 v6, p5

    move-wide/from16 v8, p7

    invoke-direct/range {v3 .. v9}, Lcom/igg/util/MD5;->I(JJJ)J

    move-result-wide v2

    add-long v2, v2, p9

    add-long v2, v2, p13

    add-long/2addr p1, v2

    .line 77
    long-to-int v2, p1

    move-wide/from16 v0, p11

    long-to-int v3, v0

    shl-int/2addr v2, v3

    long-to-int v3, p1

    const-wide/16 v4, 0x20

    sub-long v4, v4, p11

    long-to-int v4, v4

    ushr-int/2addr v3, v4

    or-int/2addr v2, v3

    int-to-long p1, v2

    .line 78
    add-long/2addr p1, p3

    .line 79
    return-wide p1
.end method

.method public static b2iu(B)J
    .locals 2
    .param p0, "byte0"    # B

    .prologue
    .line 219
    if-ltz p0, :cond_0

    int-to-long v0, p0

    :goto_0
    return-wide v0

    :cond_0
    and-int/lit16 v0, p0, 0xff

    int-to-long v0, v0

    goto :goto_0
.end method

.method public static byteHEX(B)Ljava/lang/String;
    .locals 5
    .param p0, "byte0"    # B

    .prologue
    .line 223
    const/16 v3, 0x10

    new-array v0, v3, [C

    fill-array-data v0, :array_0

    .line 225
    .local v0, "ac":[C
    const/4 v3, 0x2

    new-array v1, v3, [C

    .line 226
    .local v1, "ac1":[C
    const/4 v3, 0x0

    ushr-int/lit8 v4, p0, 0x4

    and-int/lit8 v4, v4, 0xf

    aget-char v4, v0, v4

    aput-char v4, v1, v3

    .line 227
    const/4 v3, 0x1

    and-int/lit8 v4, p0, 0xf

    aget-char v4, v0, v4

    aput-char v4, v1, v3

    .line 228
    new-instance v2, Ljava/lang/String;

    invoke-direct {v2, v1}, Ljava/lang/String;-><init>([C)V

    .line 229
    .local v2, "s":Ljava/lang/String;
    return-object v2

    .line 223
    :array_0
    .array-data 2
        0x30s
        0x31s
        0x32s
        0x33s
        0x34s
        0x35s
        0x36s
        0x37s
        0x38s
        0x39s
        0x41s
        0x42s
        0x43s
        0x44s
        0x45s
        0x46s
    .end array-data
.end method

.method private md5Final()V
    .locals 7

    .prologue
    const/16 v6, 0x8

    .line 106
    new-array v0, v6, [B

    .line 107
    .local v0, "abyte0":[B
    iget-object v3, p0, Lcom/igg/util/MD5;->count:[J

    invoke-direct {p0, v0, v3, v6}, Lcom/igg/util/MD5;->Encode([B[JI)V

    .line 108
    iget-object v3, p0, Lcom/igg/util/MD5;->count:[J

    const/4 v4, 0x0

    aget-wide v4, v3, v4

    const/4 v3, 0x3

    ushr-long/2addr v4, v3

    long-to-int v3, v4

    and-int/lit8 v1, v3, 0x3f

    .line 109
    .local v1, "i":I
    const/16 v3, 0x38

    if-lt v1, v3, :cond_0

    rsub-int/lit8 v2, v1, 0x78

    .line 110
    .local v2, "j":I
    :goto_0
    sget-object v3, Lcom/igg/util/MD5;->PADDING:[B

    invoke-direct {p0, v3, v2}, Lcom/igg/util/MD5;->md5Update([BI)V

    .line 111
    invoke-direct {p0, v0, v6}, Lcom/igg/util/MD5;->md5Update([BI)V

    .line 112
    iget-object v3, p0, Lcom/igg/util/MD5;->digest:[B

    iget-object v4, p0, Lcom/igg/util/MD5;->state:[J

    const/16 v5, 0x10

    invoke-direct {p0, v3, v4, v5}, Lcom/igg/util/MD5;->Encode([B[JI)V

    .line 113
    return-void

    .line 109
    .end local v2    # "j":I
    :cond_0
    rsub-int/lit8 v2, v1, 0x38

    goto :goto_0
.end method

.method private md5Init()V
    .locals 5

    .prologue
    const-wide/16 v2, 0x0

    const/4 v4, 0x1

    const/4 v1, 0x0

    .line 30
    iget-object v0, p0, Lcom/igg/util/MD5;->count:[J

    aput-wide v2, v0, v1

    .line 31
    iget-object v0, p0, Lcom/igg/util/MD5;->count:[J

    aput-wide v2, v0, v4

    .line 32
    iget-object v0, p0, Lcom/igg/util/MD5;->state:[J

    const-wide/32 v2, 0x67452301

    aput-wide v2, v0, v1

    .line 33
    iget-object v0, p0, Lcom/igg/util/MD5;->state:[J

    const-wide v2, 0xefcdab89L

    aput-wide v2, v0, v4

    .line 34
    iget-object v0, p0, Lcom/igg/util/MD5;->state:[J

    const/4 v1, 0x2

    const-wide v2, 0x98badcfeL

    aput-wide v2, v0, v1

    .line 35
    iget-object v0, p0, Lcom/igg/util/MD5;->state:[J

    const/4 v1, 0x3

    const-wide/32 v2, 0x10325476

    aput-wide v2, v0, v1

    .line 36
    return-void
.end method

.method private md5Memcpy([B[BIII)V
    .locals 3
    .param p1, "abyte0"    # [B
    .param p2, "abyte1"    # [B
    .param p3, "i"    # I
    .param p4, "j"    # I
    .param p5, "k"    # I

    .prologue
    .line 116
    const/4 v0, 0x0

    .local v0, "l":I
    :goto_0
    if-ge v0, p5, :cond_0

    .line 117
    add-int v1, p3, v0

    add-int v2, p4, v0

    aget-byte v2, p2, v2

    aput-byte v2, p1, v1

    .line 116
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 119
    :cond_0
    return-void
.end method

.method private md5Transform([B)V
    .locals 28
    .param p1, "abyte0"    # [B

    .prologue
    .line 122
    move-object/from16 v0, p0

    iget-object v3, v0, Lcom/igg/util/MD5;->state:[J

    const/4 v12, 0x0

    aget-wide v4, v3, v12

    .line 123
    .local v4, "l":J
    move-object/from16 v0, p0

    iget-object v3, v0, Lcom/igg/util/MD5;->state:[J

    const/4 v12, 0x1

    aget-wide v6, v3, v12

    .line 124
    .local v6, "l1":J
    move-object/from16 v0, p0

    iget-object v3, v0, Lcom/igg/util/MD5;->state:[J

    const/4 v12, 0x2

    aget-wide v8, v3, v12

    .line 125
    .local v8, "l2":J
    move-object/from16 v0, p0

    iget-object v3, v0, Lcom/igg/util/MD5;->state:[J

    const/4 v12, 0x3

    aget-wide v10, v3, v12

    .line 126
    .local v10, "l3":J
    const/16 v3, 0x10

    new-array v2, v3, [J

    .line 127
    .local v2, "al":[J
    const/16 v3, 0x40

    move-object/from16 v0, p0

    move-object/from16 v1, p1

    invoke-direct {v0, v2, v1, v3}, Lcom/igg/util/MD5;->Decode([J[BI)V

    .line 128
    const/4 v3, 0x0

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x7

    const-wide v16, 0xd76aa478L

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v4

    .line 129
    const/4 v3, 0x1

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xc

    const-wide v26, 0xe8c7b756L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v10

    .line 130
    const/4 v3, 0x2

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x11

    const-wide/32 v26, 0x242070db

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v8

    .line 131
    const/4 v3, 0x3

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x16

    const-wide v26, 0xc1bdceeeL

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v6

    .line 132
    const/4 v3, 0x4

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x7

    const-wide v16, 0xf57c0fafL

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v4

    .line 133
    const/4 v3, 0x5

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xc

    const-wide/32 v26, 0x4787c62a

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v10

    .line 134
    const/4 v3, 0x6

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x11

    const-wide v26, 0xa8304613L

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v8

    .line 135
    const/4 v3, 0x7

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x16

    const-wide v26, 0xfd469501L

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v6

    .line 136
    const/16 v3, 0x8

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x7

    const-wide/32 v16, 0x698098d8

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v4

    .line 137
    const/16 v3, 0x9

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xc

    const-wide v26, 0x8b44f7afL

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v10

    .line 138
    const/16 v3, 0xa

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x11

    const-wide v26, 0xffff5bb1L

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v8

    .line 139
    const/16 v3, 0xb

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x16

    const-wide v26, 0x895cd7beL

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v6

    .line 140
    const/16 v3, 0xc

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x7

    const-wide/32 v16, 0x6b901122

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v4

    .line 141
    const/16 v3, 0xd

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xc

    const-wide v26, 0xfd987193L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v10

    .line 142
    const/16 v3, 0xe

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x11

    const-wide v26, 0xa679438eL

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v8

    .line 143
    const/16 v3, 0xf

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x16

    const-wide/32 v26, 0x49b40821

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->FF(JJJJJJJ)J

    move-result-wide v6

    .line 144
    const/4 v3, 0x1

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x5

    const-wide v16, 0xf61e2562L

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v4

    .line 145
    const/4 v3, 0x6

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x9

    const-wide v26, 0xc040b340L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v10

    .line 146
    const/16 v3, 0xb

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xe

    const-wide/32 v26, 0x265e5a51

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v8

    .line 147
    const/4 v3, 0x0

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x14

    const-wide v26, 0xe9b6c7aaL

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v6

    .line 148
    const/4 v3, 0x5

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x5

    const-wide v16, 0xd62f105dL

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v4

    .line 149
    const/16 v3, 0xa

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x9

    const-wide/32 v26, 0x2441453

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v10

    .line 150
    const/16 v3, 0xf

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xe

    const-wide v26, 0xd8a1e681L

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v8

    .line 151
    const/4 v3, 0x4

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x14

    const-wide v26, 0xe7d3fbc8L

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v6

    .line 152
    const/16 v3, 0x9

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x5

    const-wide/32 v16, 0x21e1cde6

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v4

    .line 153
    const/16 v3, 0xe

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x9

    const-wide v26, 0xc33707d6L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v10

    .line 154
    const/4 v3, 0x3

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xe

    const-wide v26, 0xf4d50d87L

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v8

    .line 155
    const/16 v3, 0x8

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x14

    const-wide/32 v26, 0x455a14ed

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v6

    .line 156
    const/16 v3, 0xd

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x5

    const-wide v16, 0xa9e3e905L

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v4

    .line 157
    const/4 v3, 0x2

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x9

    const-wide v26, 0xfcefa3f8L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v10

    .line 158
    const/4 v3, 0x7

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xe

    const-wide/32 v26, 0x676f02d9

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v8

    .line 159
    const/16 v3, 0xc

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x14

    const-wide v26, 0x8d2a4c8aL

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->GG(JJJJJJJ)J

    move-result-wide v6

    .line 160
    const/4 v3, 0x5

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x4

    const-wide v16, 0xfffa3942L

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v4

    .line 161
    const/16 v3, 0x8

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xb

    const-wide v26, 0x8771f681L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v10

    .line 162
    const/16 v3, 0xb

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x10

    const-wide/32 v26, 0x6d9d6122

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v8

    .line 163
    const/16 v3, 0xe

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x17

    const-wide v26, 0xfde5380cL

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v6

    .line 164
    const/4 v3, 0x1

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x4

    const-wide v16, 0xa4beea44L

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v4

    .line 165
    const/4 v3, 0x4

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xb

    const-wide/32 v26, 0x4bdecfa9

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v10

    .line 166
    const/4 v3, 0x7

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x10

    const-wide v26, 0xf6bb4b60L

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v8

    .line 167
    const/16 v3, 0xa

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x17

    const-wide v26, 0xbebfbc70L

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v6

    .line 168
    const/16 v3, 0xd

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x4

    const-wide/32 v16, 0x289b7ec6

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v4

    .line 169
    const/4 v3, 0x0

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xb

    const-wide v26, 0xeaa127faL

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v10

    .line 170
    const/4 v3, 0x3

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x10

    const-wide v26, 0xd4ef3085L

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v8

    .line 171
    const/4 v3, 0x6

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x17

    const-wide/32 v26, 0x4881d05

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v6

    .line 172
    const/16 v3, 0x9

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x4

    const-wide v16, 0xd9d4d039L

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v4

    .line 173
    const/16 v3, 0xc

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xb

    const-wide v26, 0xe6db99e5L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v10

    .line 174
    const/16 v3, 0xf

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x10

    const-wide/32 v26, 0x1fa27cf8

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v8

    .line 175
    const/4 v3, 0x2

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x17

    const-wide v26, 0xc4ac5665L

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->HH(JJJJJJJ)J

    move-result-wide v6

    .line 176
    const/4 v3, 0x0

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x6

    const-wide v16, 0xf4292244L

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v4

    .line 177
    const/4 v3, 0x7

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xa

    const-wide/32 v26, 0x432aff97

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v10

    .line 178
    const/16 v3, 0xe

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xf

    const-wide v26, 0xab9423a7L

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v8

    .line 179
    const/4 v3, 0x5

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x15

    const-wide v26, 0xfc93a039L

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v6

    .line 180
    const/16 v3, 0xc

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x6

    const-wide/32 v16, 0x655b59c3

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v4

    .line 181
    const/4 v3, 0x3

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xa

    const-wide v26, 0x8f0ccc92L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v10

    .line 182
    const/16 v3, 0xa

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xf

    const-wide v26, 0xffeff47dL

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v8

    .line 183
    const/4 v3, 0x1

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x15

    const-wide v26, 0x85845dd1L

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v6

    .line 184
    const/16 v3, 0x8

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x6

    const-wide/32 v16, 0x6fa87e4f

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v4

    .line 185
    const/16 v3, 0xf

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xa

    const-wide v26, 0xfe2ce6e0L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v10

    .line 186
    const/4 v3, 0x6

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xf

    const-wide v26, 0xa3014314L

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v8

    .line 187
    const/16 v3, 0xd

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x15

    const-wide/32 v26, 0x4e0811a1

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v6

    .line 188
    const/4 v3, 0x4

    aget-wide v12, v2, v3

    const-wide/16 v14, 0x6

    const-wide v16, 0xf7537e82L

    move-object/from16 v3, p0

    invoke-direct/range {v3 .. v17}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v4

    .line 189
    const/16 v3, 0xb

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xa

    const-wide v26, 0xbd3af235L

    move-object/from16 v13, p0

    move-wide v14, v10

    move-wide/from16 v16, v4

    move-wide/from16 v18, v6

    move-wide/from16 v20, v8

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v10

    .line 190
    const/4 v3, 0x2

    aget-wide v22, v2, v3

    const-wide/16 v24, 0xf

    const-wide/32 v26, 0x2ad7d2bb

    move-object/from16 v13, p0

    move-wide v14, v8

    move-wide/from16 v16, v10

    move-wide/from16 v18, v4

    move-wide/from16 v20, v6

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v8

    .line 191
    const/16 v3, 0x9

    aget-wide v22, v2, v3

    const-wide/16 v24, 0x15

    const-wide v26, 0xeb86d391L

    move-object/from16 v13, p0

    move-wide v14, v6

    move-wide/from16 v16, v8

    move-wide/from16 v18, v10

    move-wide/from16 v20, v4

    invoke-direct/range {v13 .. v27}, Lcom/igg/util/MD5;->II(JJJJJJJ)J

    move-result-wide v6

    .line 192
    move-object/from16 v0, p0

    iget-object v3, v0, Lcom/igg/util/MD5;->state:[J

    const/4 v12, 0x0

    aget-wide v14, v3, v12

    add-long/2addr v14, v4

    aput-wide v14, v3, v12

    .line 193
    move-object/from16 v0, p0

    iget-object v3, v0, Lcom/igg/util/MD5;->state:[J

    const/4 v12, 0x1

    aget-wide v14, v3, v12

    add-long/2addr v14, v6

    aput-wide v14, v3, v12

    .line 194
    move-object/from16 v0, p0

    iget-object v3, v0, Lcom/igg/util/MD5;->state:[J

    const/4 v12, 0x2

    aget-wide v14, v3, v12

    add-long/2addr v14, v8

    aput-wide v14, v3, v12

    .line 195
    move-object/from16 v0, p0

    iget-object v3, v0, Lcom/igg/util/MD5;->state:[J

    const/4 v12, 0x3

    aget-wide v14, v3, v12

    add-long/2addr v14, v10

    aput-wide v14, v3, v12

    .line 196
    return-void
.end method

.method private md5Update([BI)V
    .locals 19
    .param p1, "abyte0"    # [B
    .param p2, "i"    # I

    .prologue
    .line 83
    const/16 v2, 0x40

    new-array v9, v2, [B

    .line 84
    .local v9, "abyte1":[B
    move-object/from16 v0, p0

    iget-object v2, v0, Lcom/igg/util/MD5;->count:[J

    const/4 v3, 0x0

    aget-wide v2, v2, v3

    const/4 v4, 0x3

    ushr-long/2addr v2, v4

    long-to-int v2, v2

    and-int/lit8 v5, v2, 0x3f

    .line 85
    .local v5, "k":I
    move-object/from16 v0, p0

    iget-object v2, v0, Lcom/igg/util/MD5;->count:[J

    const/4 v3, 0x0

    aget-wide v10, v2, v3

    shl-int/lit8 v4, p2, 0x3

    int-to-long v14, v4

    add-long/2addr v10, v14

    aput-wide v10, v2, v3

    shl-int/lit8 v2, p2, 0x3

    int-to-long v2, v2

    cmp-long v2, v10, v2

    if-gez v2, :cond_0

    .line 86
    move-object/from16 v0, p0

    iget-object v2, v0, Lcom/igg/util/MD5;->count:[J

    const/4 v3, 0x1

    aget-wide v10, v2, v3

    const-wide/16 v14, 0x1

    add-long/2addr v10, v14

    aput-wide v10, v2, v3

    .line 87
    :cond_0
    move-object/from16 v0, p0

    iget-object v2, v0, Lcom/igg/util/MD5;->count:[J

    const/4 v3, 0x1

    aget-wide v10, v2, v3

    ushr-int/lit8 v4, p2, 0x1d

    int-to-long v14, v4

    add-long/2addr v10, v14

    aput-wide v10, v2, v3

    .line 88
    rsub-int/lit8 v7, v5, 0x40

    .line 90
    .local v7, "l":I
    move/from16 v0, p2

    if-lt v0, v7, :cond_2

    .line 91
    move-object/from16 v0, p0

    iget-object v3, v0, Lcom/igg/util/MD5;->buffer:[B

    const/4 v6, 0x0

    move-object/from16 v2, p0

    move-object/from16 v4, p1

    invoke-direct/range {v2 .. v7}, Lcom/igg/util/MD5;->md5Memcpy([B[BIII)V

    .line 92
    move-object/from16 v0, p0

    iget-object v2, v0, Lcom/igg/util/MD5;->buffer:[B

    move-object/from16 v0, p0

    invoke-direct {v0, v2}, Lcom/igg/util/MD5;->md5Transform([B)V

    .line 93
    move v12, v7

    .local v12, "j":I
    :goto_0
    add-int/lit8 v2, v12, 0x3f

    move/from16 v0, p2

    if-ge v2, v0, :cond_1

    .line 94
    const/4 v11, 0x0

    const/16 v13, 0x40

    move-object/from16 v8, p0

    move-object/from16 v10, p1

    invoke-direct/range {v8 .. v13}, Lcom/igg/util/MD5;->md5Memcpy([B[BIII)V

    .line 95
    move-object/from16 v0, p0

    invoke-direct {v0, v9}, Lcom/igg/util/MD5;->md5Transform([B)V

    .line 93
    add-int/lit8 v12, v12, 0x40

    goto :goto_0

    .line 98
    :cond_1
    const/4 v5, 0x0

    .line 102
    :goto_1
    move-object/from16 v0, p0

    iget-object v14, v0, Lcom/igg/util/MD5;->buffer:[B

    sub-int v18, p2, v12

    move-object/from16 v13, p0

    move-object/from16 v15, p1

    move/from16 v16, v5

    move/from16 v17, v12

    invoke-direct/range {v13 .. v18}, Lcom/igg/util/MD5;->md5Memcpy([B[BIII)V

    .line 103
    return-void

    .line 100
    .end local v12    # "j":I
    :cond_2
    const/4 v12, 0x0

    .restart local v12    # "j":I
    goto :goto_1
.end method


# virtual methods
.method public getMD5ofStr(Ljava/lang/String;)Ljava/lang/String;
    .locals 3
    .param p1, "s"    # Ljava/lang/String;

    .prologue
    .line 11
    invoke-direct {p0}, Lcom/igg/util/MD5;->md5Init()V

    .line 12
    invoke-virtual {p1}, Ljava/lang/String;->getBytes()[B

    move-result-object v1

    invoke-virtual {p1}, Ljava/lang/String;->length()I

    move-result v2

    invoke-direct {p0, v1, v2}, Lcom/igg/util/MD5;->md5Update([BI)V

    .line 13
    invoke-direct {p0}, Lcom/igg/util/MD5;->md5Final()V

    .line 14
    const-string v1, ""

    iput-object v1, p0, Lcom/igg/util/MD5;->digestHexStr:Ljava/lang/String;

    .line 15
    const/4 v0, 0x0

    .local v0, "i":I
    :goto_0
    const/16 v1, 0x10

    if-ge v0, v1, :cond_0

    .line 16
    new-instance v1, Ljava/lang/StringBuilder;

    invoke-direct {v1}, Ljava/lang/StringBuilder;-><init>()V

    iget-object v2, p0, Lcom/igg/util/MD5;->digestHexStr:Ljava/lang/String;

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    iget-object v2, p0, Lcom/igg/util/MD5;->digest:[B

    aget-byte v2, v2, v0

    invoke-static {v2}, Lcom/igg/util/MD5;->byteHEX(B)Ljava/lang/String;

    move-result-object v2

    invoke-virtual {v1, v2}, Ljava/lang/StringBuilder;->append(Ljava/lang/String;)Ljava/lang/StringBuilder;

    move-result-object v1

    invoke-virtual {v1}, Ljava/lang/StringBuilder;->toString()Ljava/lang/String;

    move-result-object v1

    iput-object v1, p0, Lcom/igg/util/MD5;->digestHexStr:Ljava/lang/String;

    .line 15
    add-int/lit8 v0, v0, 0x1

    goto :goto_0

    .line 18
    :cond_0
    iget-object v1, p0, Lcom/igg/util/MD5;->digestHexStr:Ljava/lang/String;

    return-object v1
.end method
